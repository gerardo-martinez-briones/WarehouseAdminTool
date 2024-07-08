using Core.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class TrackingRepository : ITrackingRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TrackingRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<double> GetProgressPercentageAsync(int idPurchaseOrder)
    {
        double totalOrdered = await _dbContext.PurchaseOrderDetails
            .Where(x => x.IdPurchaseOrder == idPurchaseOrder).SumAsync(s => s.Ordered);

        double totalTracking = await _dbContext.Trackings.
            Where(x => x.PurchaseOrderDetail.IdPurchaseOrder == idPurchaseOrder)
            .CountAsync();

        return ((totalTracking / totalOrdered) * 100);
    }

    public async Task<int> GetCountTrackingsAsync(int idPurchaseOrder)
    {
        var response = await _dbContext.Trackings.
            Where(x => x.PurchaseOrderDetail.IdPurchaseOrder == idPurchaseOrder)
            .CountAsync();

        return response;
    }

    public async Task<int> CreateTrackingAsync(Tracking entity)
    {
        await _dbContext.Trackings.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity.IdTracking;
    }
}