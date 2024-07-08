using MediatR;

namespace Core.Features.Trackings.Queries.GetCountTrackings;

public class GetCountTrackingsQuery : IRequest<int>
{
    public int IdPurchaseOrder { get; set; }
}