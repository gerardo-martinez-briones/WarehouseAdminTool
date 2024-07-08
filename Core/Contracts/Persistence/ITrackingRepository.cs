using Domain;

namespace Core.Contracts.Persistence;

public interface ITrackingRepository
{
    Task<double> GetProgressPercentageAsync(int idPurchaseOrder);
    Task<int> GetCountTrackingsAsync(int idPurchaseOrder);
    Task<int> CreateTrackingAsync(Tracking entity);
}