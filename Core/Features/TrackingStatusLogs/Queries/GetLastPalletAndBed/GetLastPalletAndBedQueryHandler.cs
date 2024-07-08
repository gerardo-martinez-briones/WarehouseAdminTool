using Core.Contracts.Persistence;
using Domain;
using MediatR;

namespace Core.Features.TrackingStatusLogs.Queries.GetLastPalletAndBed;

public class GetLastPalletAndBedQueryHandler : IRequestHandler<GetLastPalletAndBedQuery, TrackingStatusLog>
{
    private readonly ITrackingStatusLogRepository _trackingStatusLogRepository;

    public GetLastPalletAndBedQueryHandler(ITrackingStatusLogRepository trackingStatusLogRepository)
    {
        _trackingStatusLogRepository = trackingStatusLogRepository;
    }

    public async Task<TrackingStatusLog> Handle(GetLastPalletAndBedQuery request, CancellationToken cancellationToken)
    {
        var response = await _trackingStatusLogRepository.GetLastPalletAndBedAsync(request.IdPurchaseOrder, request.HostName, request.IdUser);

        return response;
    }
}