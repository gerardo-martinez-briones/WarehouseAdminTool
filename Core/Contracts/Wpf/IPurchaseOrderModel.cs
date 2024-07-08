namespace Core.Contracts.Wpf;

public interface IPurchaseOrderModel
{
    int IdPurchaseOrder { get; set; }
    int IdUser { get; set; }
    string OrderNumber { get; set; }
    string OrderDate { get; set; }
    string ReqShipDate { get; set; }
    string CustomerPO { get; set; }
    string CustomerName { get; set; }
    string Comments { get; set; }
    string Status { get; set; }
    double Progress { get; set; }
}