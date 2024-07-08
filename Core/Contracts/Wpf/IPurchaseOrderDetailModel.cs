namespace Core.Contracts.Wpf;

public interface IPurchaseOrderDetailModel
{
    int IdPurchaseOrderDetail { get; set; }
    int IdPurchaseOrder { get; set; }
    int IdUser { get; set; }
    string SKU { get; set; }
    string ItemNumber { get; set; }
    string ItemDescription { get; set; }
    string Unit { get; set; }
    int Ordered { get; set; }
    bool Edited { get; set; }
}