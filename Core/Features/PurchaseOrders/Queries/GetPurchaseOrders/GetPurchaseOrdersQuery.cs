using Domain;
using MediatR;

namespace Core.Features.PurchaseOrders.Queries.GetPurchaseOrders;

public class GetPurchaseOrdersQuery : IRequest<List<PurchaseOrder>>
{
    public string Filter { get; set; }
}