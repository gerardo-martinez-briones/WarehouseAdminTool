using Core.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;


public class TrackingStatusLogRepository : ITrackingStatusLogRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TrackingStatusLogRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TrackingStatusLog> GetLastPalletAndBedAsync(int idPurchaseOrder, string hostName, int idUser)
    {
        var response = await _dbContext.TrackingStatusLogs
            .Where(x => x.IdPurchaseOrder == idPurchaseOrder && x.HostName == hostName && x.IsCompleted == false)
            .OrderByDescending(x => x.IdTrackingStatusLog)
            .FirstOrDefaultAsync();

        if (response != null)
        {
            response.PalletNumber = response.PalletNumber;
            response.BedNumber = response.BedNumber;
        }
        else
        {
            response = await _dbContext.TrackingStatusLogs
                .Where(x => x.IdPurchaseOrder == idPurchaseOrder)
                .OrderByDescending(x => x.IdTrackingStatusLog)
                .FirstOrDefaultAsync();

            if (response != null)
            {
                response.PalletNumber = response.PalletNumber + 1;
                response.BedNumber = response.BedNumber + 1;
            }
        }

        if (response == null)
        {
            response = new();

            response.IdPurchaseOrder = idPurchaseOrder;
            response.HostName = hostName;
            response.PalletNumber = 1;
            response.BedNumber = 1;
            response.IsCompleted = false;
            response.CreatedBy = idUser;

            await _dbContext.TrackingStatusLogs.AddAsync(response);
            await _dbContext.SaveChangesAsync();
        }

        return response;
    }
}