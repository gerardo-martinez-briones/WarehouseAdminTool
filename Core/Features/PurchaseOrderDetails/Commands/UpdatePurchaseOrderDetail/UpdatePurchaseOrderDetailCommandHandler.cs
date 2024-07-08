using Core.Contracts.Persistence;
using Domain;
using MediatR;

namespace Core.Features.PurchaseOrderDetails.Commands.UpdatePurchaseOrderDetail;

public class UpdatePurchaseOrderDetailCommandHandler : IRequestHandler<UpdatePurchaseOrderDetailCommand, int>
{
    private readonly IPurchaseOrderDetailRepository _PurchaseOrderDetailRepository;

    public UpdatePurchaseOrderDetailCommandHandler(IPurchaseOrderDetailRepository purchaseOrderDetailRepository)
    {
        _PurchaseOrderDetailRepository = purchaseOrderDetailRepository;
    }

    public async Task<int> Handle(UpdatePurchaseOrderDetailCommand request, CancellationToken cancellationToken)
    {
        List<PurchaseOrderDetail> PurchaseOrderDetails = new();

        foreach (var purchaseOrderDetailItem in request.PurchaseOrderDetails)
        {
            PurchaseOrderDetail purchaseOrderDetail = await _PurchaseOrderDetailRepository.GetPurchaseOrderDetailAsync(purchaseOrderDetailItem.IdPurchaseOrderDetail);

            if (purchaseOrderDetail != null)
            {
                purchaseOrderDetail.SKU = purchaseOrderDetailItem.SKU;
                purchaseOrderDetail.EditedBy = request.EditedBy;
                purchaseOrderDetail.EditedAt = request.EditedAt;

                PurchaseOrderDetails.Add(purchaseOrderDetail);
            }
        }

        var response = await _PurchaseOrderDetailRepository.UpdatePurchaseOrderDetailAsync(PurchaseOrderDetails);

        return response;
    }
}
