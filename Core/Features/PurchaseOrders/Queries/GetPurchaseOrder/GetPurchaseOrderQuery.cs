using Domain;
using MediatR;

namespace Core.Features.PurchaseOrders.Queries.GetPurchaseOrder;

public class GetPurchaseOrderQuery : IRequest<PurchaseOrder>
{
    public int IdPurchaseOrder { get; set; }
}