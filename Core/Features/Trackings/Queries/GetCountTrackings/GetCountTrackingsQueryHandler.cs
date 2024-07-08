using Core.Contracts.Persistence;
using MediatR;

namespace Core.Features.Trackings.Queries.GetCountTrackings;

public class GetCountTrackingsQueryHandler : IRequestHandler<GetCountTrackingsQuery, int>
{
    private readonly ITrackingRepository _trackingRepository;

    public GetCountTrackingsQueryHandler(ITrackingRepository trackingRepository)
    {
        _trackingRepository = trackingRepository;
    }

    public async Task<int> Handle(GetCountTrackingsQuery request, CancellationToken cancellationToken)
    {
        var response = await _trackingRepository.GetCountTrackingsAsync(request.IdPurchaseOrder);

        return response;
    }
}