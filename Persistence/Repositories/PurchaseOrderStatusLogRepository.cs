using Core.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class PurchaseOrderStatusLogRepository : IPurchaseOrderStatusLogRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PurchaseOrderStatusLogRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreatePurchaseOrderStatusLogAsync(PurchaseOrderStatusLog entity)
    {
        await _dbContext.PurchaseOrderStatusLogs.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity.IdPurchaseOrderStatusLog;
    }

    public async Task<Status> GetLastStatusAsync(int idPurchaseOrder)
    {
        var response = await _dbContext.PurchaseOrderStatusLogs
            .Include(i => i.Status)
            .Where(x => x.IdPurchaseOrder == idPurchaseOrder)
            .OrderByDescending(x => x.IdPurchaseOrderStatusLog)
            .FirstOrDefaultAsync();

        return response.Status;
    }
}