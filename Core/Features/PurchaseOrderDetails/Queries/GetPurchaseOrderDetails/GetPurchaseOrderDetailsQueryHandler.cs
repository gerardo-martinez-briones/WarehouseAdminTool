using Core.Contracts.Persistence;
using Domain;
using MediatR;

namespace Core.Features.PurchaseOrderDetails.Queries.GetPurchaseOrderDetails;

public class GetPurchaseOrderDetailsQueryHandler : IRequestHandler<GetPurchaseOrderDetailsQuery, List<PurchaseOrderDetail>>
{
    private readonly IPurchaseOrderDetailRepository _purchaseOrderDetailRepository;

    public GetPurchaseOrderDetailsQueryHandler(IPurchaseOrderDetailRepository purchaseOrderDetailRepository)
    {
        _purchaseOrderDetailRepository = purchaseOrderDetailRepository;
    }

    public async Task<List<PurchaseOrderDetail>> Handle(GetPurchaseOrderDetailsQuery request, CancellationToken cancellationToken)
    {
        var response = await _purchaseOrderDetailRepository.GetPurchaseOrderDetailsAsync(request.IdPurchaseOrder, request.Filter);

        return response;
    }
}