using Domain;

namespace Core.Contracts.Persistence;

public interface IPurchaseOrderDetailRepository
{
    Task<PurchaseOrderDetail> GetPurchaseOrderDetailAsync(int id);
    Task<List<PurchaseOrderDetail>> GetPurchaseOrderDetailsAsync(int IdPurchaseOrder, string filter = "");
    Task<int> CreatePurchaseOrderDetailAsync(List<PurchaseOrderDetail> entities);
    Task<int> UpdatePurchaseOrderDetailAsync(List<PurchaseOrderDetail> PurchaseOrderDetails);
}