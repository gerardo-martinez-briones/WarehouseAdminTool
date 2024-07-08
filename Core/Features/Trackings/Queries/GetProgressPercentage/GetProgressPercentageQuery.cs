using MediatR;

namespace Core.Features.Trackings.Queries.GetProgressPercentage;

public class GetProgressPercentageQuery : IRequest<double>
{
    public int IdPurchaseOrder { get; set; }
}