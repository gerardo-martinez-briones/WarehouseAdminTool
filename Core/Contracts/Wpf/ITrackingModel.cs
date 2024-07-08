namespace Core.Contracts.Wpf;

public interface ITrackingModel
{
    int IdTracking { get; set; }
    int IdPurchaseOrderDetail { get; set; }
    string HostName { get; set; }
    string OrderNumber { get; set; }
    string SKU { get; set; }
    string ItemNumber { get; set; }
    string PalletNumber { get; set; }
    string BedNumber { get; set; }
    int CreatedBy { get; set; }
    int ReviewedBy { get; set; }
    string CreatedAt { get; set; }
}