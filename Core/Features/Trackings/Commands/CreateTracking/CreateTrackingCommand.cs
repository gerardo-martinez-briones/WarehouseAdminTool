using MediatR;

namespace Core.Features.Trackings.Commands.CreateTracking;

public class CreateTrackingCommand : IRequest<int>
{
    public int IdTracking { get; set; }
    public int IdPurchaseOrderDetail { get; set; }
    public string HostName { get; set; }
    public string OrderNumber { get; set; }
    public string SKU { get; set; }
    public string ItemNumber { get; set; }
    public byte PalletNumber { get; set; }
    public byte BedNumber { get; set; }
    public int CreatedBy { get; set; }
    public int ReviewedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}