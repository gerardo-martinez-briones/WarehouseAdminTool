using Domain;
using MediatR;

namespace Core.Features.TrackingStatusLogs.Queries.GetLastPalletAndBed;

public class GetLastPalletAndBedQuery : IRequest<TrackingStatusLog>
{
    public int IdPurchaseOrder { get; set; }
    public string HostName { get; set; }
    public int IdUser { get; set; }
}