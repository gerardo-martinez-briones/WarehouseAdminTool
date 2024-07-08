using Domain;

namespace Core.Contracts.Persistence;

public interface IPurchaseOrderStatusLogRepository
{
    Task<int> CreatePurchaseOrderStatusLogAsync(PurchaseOrderStatusLog entity);
    Task<Status> GetLastStatusAsync(int idPurchaseOrder);
}