using Core.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class PurchaseOrderDetailRepository : IPurchaseOrderDetailRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PurchaseOrderDetailRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PurchaseOrderDetail> GetPurchaseOrderDetailAsync(int id)
    {
        var response = await _dbContext.PurchaseOrderDetails.Include(i => i.PurchaseOrder)
            .Where(x => x.IdPurchaseOrderDetail == id && x.IsActive == true)
            .FirstOrDefaultAsync();

        return response;
    }

    public async Task<List<PurchaseOrderDetail>> GetPurchaseOrderDetailsAsync(int IdPurchaseOrder, string filter = "")
    {
        if (string.IsNullOrWhiteSpace(filter))
            return await _dbContext.PurchaseOrderDetails.Include(i => i.PurchaseOrder)
                .Where(x => x.IsActive == true && x.IdPurchaseOrder == IdPurchaseOrder)
                .OrderBy(o => o.SKU)
                .ToListAsync();
        else
        {
            return await _dbContext.PurchaseOrderDetails.Include(i => i.PurchaseOrder)
                .Where(x => x.IsActive == true && x.IdPurchaseOrder == IdPurchaseOrder && (x.SKU.Contains(filter)
                    || x.ItemNumber.Contains(filter)
                    || x.ItemDescription.Contains(filter)
                    || x.Unit.Contains(filter)
                    || x.Ordered.ToString().Contains(filter)))
                .OrderBy(o => o.SKU)
                .ToListAsync();
        }
    }

    public async Task<int> CreatePurchaseOrderDetailAsync(List<PurchaseOrderDetail> PurchaseOrderDetails)
    {
        foreach (var PurchaseOrderDetail in PurchaseOrderDetails)
            await _dbContext.PurchaseOrderDetails.AddAsync(PurchaseOrderDetail);

        await _dbContext.SaveChangesAsync();

        return PurchaseOrderDetails.Count;
    }

    public async Task<int> UpdatePurchaseOrderDetailAsync(List<PurchaseOrderDetail> PurchaseOrderDetails)
    {
        foreach (var PurchaseOrderDetail in PurchaseOrderDetails)
            _dbContext.Entry(PurchaseOrderDetail).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();

        return PurchaseOrderDetails.Count;
    }
}