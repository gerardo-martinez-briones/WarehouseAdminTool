using Core.Contracts.Persistence;
using Domain;
using MediatR;

namespace Core.Features.Trackings.Commands.CreateTracking;

public class CreateTrackingCommandHandler : IRequestHandler<CreateTrackingCommand, int>
{
    private readonly ITrackingRepository _trackingRepository;

    public CreateTrackingCommandHandler(ITrackingRepository trackingRepository)
    {
        _trackingRepository = trackingRepository;
    }

    public async Task<int> Handle(CreateTrackingCommand request, CancellationToken cancellationToken)
    {
        Tracking tracking = new();

        tracking.IdTracking = request.IdTracking;
        tracking.IdPurchaseOrderDetail = request.IdPurchaseOrderDetail;
        tracking.HostName = request.HostName;
        tracking.OrderNumber = request.OrderNumber;
        tracking.SKU = request.SKU;
        tracking.ItemNumber = request.ItemNumber;
        tracking.PalletNumber = request.PalletNumber;
        tracking.BedNumber = request.BedNumber;
        tracking.CreatedBy = request.CreatedBy;
        tracking.ReviewedBy = request.ReviewedBy;

        var response = await _trackingRepository.CreateTrackingAsync(tracking);

        return response;
    }
}