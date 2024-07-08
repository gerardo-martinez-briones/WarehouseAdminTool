using Domain;

namespace Core.Contracts.Persistence;

public interface IPurchaseOrderRepository
{
    Task<PurchaseOrder> GetPurchaseOrderAsync(int id);
    Task<List<PurchaseOrder>> GetPurchaseOrdersAsync(string filter = "");
    Task<int> CreatePurchaseOrderAsync(PurchaseOrder entity);
}