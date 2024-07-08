using Core.Contracts.Persistence;
using Domain;
using MediatR;

namespace Core.Features.PurchaseOrderStatusLogs.Queries.GetLastStatus;

public class GetLastStatusQueryHandler : IRequestHandler<GetLastStatusQuery, Status>
{
    private readonly IPurchaseOrderStatusLogRepository _purchaseOrderStatusLogRepository;

    public GetLastStatusQueryHandler(IPurchaseOrderStatusLogRepository purchaseOrderStatusLogRepository)
    {
        _purchaseOrderStatusLogRepository = purchaseOrderStatusLogRepository;
    }

    public Task<Status> Handle(GetLastStatusQuery request, CancellationToken cancellationToken)
    {
        var response = _purchaseOrderStatusLogRepository.GetLastStatusAsync(request.IdPurchaseOrder);

        return response;
    }
}