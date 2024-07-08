using Domain;
using MediatR;

namespace Core.Features.PurchaseOrderStatusLogs.Queries.GetLastStatus;

public class GetLastStatusQuery : IRequest<Status>
{
    public int IdPurchaseOrder { get; set; }
}