using Domain;
using MediatR;

namespace Core.Features.PurchaseOrderDetails.Queries.GetPurchaseOrderDetails;

public class GetPurchaseOrderDetailsQuery : IRequest<List<PurchaseOrderDetail>>
{
    public int IdPurchaseOrder { get; set; }
    public string Filter { get; set; }
}