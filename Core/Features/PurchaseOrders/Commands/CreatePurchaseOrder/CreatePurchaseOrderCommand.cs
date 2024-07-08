using MediatR;

namespace Core.Features.PurchaseOrders.Commands.CreatePurchaseOrder;

public class CreatePurchaseOrderCommand : IRequest<int>
{
    public string OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ReqShipDate { get; set; }
    public string CustomerPO { get; set; }
    public string CustomerName { get; set; }
    public string Comments { get; set; }
    public int IdUser { get; set; }
}