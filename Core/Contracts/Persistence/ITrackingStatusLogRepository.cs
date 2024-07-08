using Domain;

namespace Core.Contracts.Persistence;

public interface ITrackingStatusLogRepository
{
    Task<TrackingStatusLog> GetLastPalletAndBedAsync(int idPurchaseOrder, string hostName, int idUser);
}