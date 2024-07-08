using Core.Contracts.Persistence;
using Domain;
using MediatR;

namespace Core.Features.PurchaseOrders.Queries.GetPurchaseOrders;

public class GetPurchaseOrdersQueryHandler : IRequestHandler<GetPurchaseOrdersQuery, List<PurchaseOrder>>
{
    private readonly IPurchaseOrderRepository _purchaseOrderRepository;

    public GetPurchaseOrdersQueryHandler(IPurchaseOrderRepository purchaseOrderRepository)
    {
        _purchaseOrderRepository = purchaseOrderRepository;
    }

    public async Task<List<PurchaseOrder>> Handle(GetPurchaseOrdersQuery request, CancellationToken cancellationToken)
    {
        var response = await _purchaseOrderRepository.GetPurchaseOrdersAsync(request.Filter);

        return response;
    }
}