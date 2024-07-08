using Core.Contracts.Persistence;
using MediatR;

namespace Core.Features.PurchaseOrderStatusLogs.Commands.CreatePurchaseOrderStatusLog;

public class CreatePurchaseOrderStatusLogCommandHandler : IRequestHandler<CreatePurchaseOrderStatusLogCommand, int>
{
    private readonly IPurchaseOrderStatusLogRepository _purchaseOrderStatusLogRepository;

    public CreatePurchaseOrderStatusLogCommandHandler(IPurchaseOrderStatusLogRepository purchaseOrderStatusLogRepository)
    {
        _purchaseOrderStatusLogRepository = purchaseOrderStatusLogRepository;
    }

    public async Task<int> Handle(CreatePurchaseOrderStatusLogCommand request, CancellationToken cancellationToken)
    {
        Domain.PurchaseOrderStatusLog purchaseOrderStatusLog = new();

        purchaseOrderStatusLog.IdPurchaseOrder = request.IdPurchaseOrder;
        purchaseOrderStatusLog.IdStatus = request.IdStatus;
        purchaseOrderStatusLog.IdUser = request.IdUser;
        purchaseOrderStatusLog.Comments = request.Comments;

        var response = await _purchaseOrderStatusLogRepository.CreatePurchaseOrderStatusLogAsync(purchaseOrderStatusLog);

        return response;
    }
}