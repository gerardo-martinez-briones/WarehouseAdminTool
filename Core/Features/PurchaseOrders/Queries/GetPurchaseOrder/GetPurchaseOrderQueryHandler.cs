using Core.Contracts.Persistence;
using Domain;
using MediatR;

namespace Core.Features.PurchaseOrders.Queries.GetPurchaseOrder;

public class GetPurchaseOrderQueryHandler : IRequestHandler<GetPurchaseOrderQuery, PurchaseOrder>
{
    private readonly IPurchaseOrderRepository _purchaseOrderRepository;

    public GetPurchaseOrderQueryHandler(IPurchaseOrderRepository purchaseOrderRepository)
    {
        _purchaseOrderRepository = purchaseOrderRepository;
    }

    public async Task<PurchaseOrder> Handle(GetPurchaseOrderQuery request, CancellationToken cancellationToken)
    {
        var response = await _purchaseOrderRepository.GetPurchaseOrderAsync(request.IdPurchaseOrder);

        return response;
    }
}
