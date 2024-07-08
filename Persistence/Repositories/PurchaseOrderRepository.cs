using Core.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class PurchaseOrderRepository : IPurchaseOrderRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PurchaseOrderRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PurchaseOrder> GetPurchaseOrderAsync(int id)
    {
        var response = await _dbContext.PurchaseOrders.Include(i => i.PurchaseOrderDetails)
            .Where(x => x.IdPurchaseOrder == id && x.IsActive == true)
            .FirstOrDefaultAsync();

        return response;
    }

    public async Task<List<PurchaseOrder>> GetPurchaseOrdersAsync(string filter = "")
    {
        if (string.IsNullOrWhiteSpace(filter))
            return await _dbContext.PurchaseOrders.Include(i => i.PurchaseOrderDetails)
                .Where(x => x.IsActive == true)
                .ToListAsync();
        else
        {
            return await _dbContext.PurchaseOrders.Include(i => i.PurchaseOrderDetails)
                .Where(x => x.IsActive == true
                    && (x.OrderNumber.Contains(filter)
                        || x.CustomerPO.Contains(filter)
                        || x.CustomerName.Contains(filter)
                        || x.Comments.Contains(filter)))
                .ToListAsync();
        }
    }

    public async Task<int> CreatePurchaseOrderAsync(PurchaseOrder entity)
    {
        if (_dbContext.PurchaseOrders.Any(x => x.CustomerPO.Equals(entity.CustomerPO)
            || x.OrderNumber.Equals(entity.OrderNumber)))
            throw new Exception($"¡La Orden de Compra {entity.CustomerPO} YA Existe en la Base de Datos!");

        await _dbContext.PurchaseOrders.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity.IdPurchaseOrder;
    }
}