using Core.Contracts.Persistence;
using MediatR;

namespace Core.Features.Trackings.Queries.GetProgressPercentage;

public class GetProgressPercentageQueryHandler : IRequestHandler<GetProgressPercentageQuery, double>
{
    private readonly ITrackingRepository _trackingRepository;

    public GetProgressPercentageQueryHandler(ITrackingRepository trackingRepository)
    {
        _trackingRepository = trackingRepository;
    }

    public async Task<double> Handle(GetProgressPercentageQuery request, CancellationToken cancellationToken)
    {
        var response = await _trackingRepository.GetProgressPercentageAsync(request.IdPurchaseOrder);

        return response;
    }
}