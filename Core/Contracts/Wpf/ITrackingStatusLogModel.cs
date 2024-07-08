namespace Core.Contracts.Wpf;

public interface ITrackingStatusLogModel
{
    int IdTrackingStatusLog { get; set; }
    int IdPurchaseOrder { get; set; }
    string HostName { get; set; }
    string PalletNumber { get; set; }
    string BedNumber { get; set; }
    bool IsCompleted { get; set; }
}