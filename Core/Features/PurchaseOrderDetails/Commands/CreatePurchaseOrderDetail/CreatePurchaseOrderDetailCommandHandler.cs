using Core.Contracts.Persistence;
using Domain;
using MediatR;

namespace Core.Features.PurchaseOrderDetails.Commands.CreatePurchaseOrderDetail;

public class CreatePurchaseOrderDetailCommandHandler : IRequestHandler<CreatePurchaseOrderDetailCommand, int>
{
    private readonly IPurchaseOrderDetailRepository _PurchaseOrderDetailRepository;

    public CreatePurchaseOrderDetailCommandHandler(IPurchaseOrderDetailRepository purchaseOrderDetailRepository)
    {
        _PurchaseOrderDetailRepository = purchaseOrderDetailRepository;
    }

    public async Task<int> Handle(CreatePurchaseOrderDetailCommand request, CancellationToken cancellationToken)
    {
        List<PurchaseOrderDetail> PurchaseOrderDetails = new();

        foreach (var purchaseOrderDetail in request.PurchaseOrderDetails)
        {
            Domain.PurchaseOrderDetail PurchaseOrderDetailEntity = new();

            PurchaseOrderDetailEntity.IdPurchaseOrder = purchaseOrderDetail.IdPurchaseOrder;
            PurchaseOrderDetailEntity.SKU = purchaseOrderDetail.SKU;
            PurchaseOrderDetailEntity.ItemNumber = purchaseOrderDetail.ItemNumber;
            PurchaseOrderDetailEntity.ItemDescription = purchaseOrderDetail.ItemDescription;
            PurchaseOrderDetailEntity.Unit = purchaseOrderDetail.Unit;
            PurchaseOrderDetailEntity.Ordered = purchaseOrderDetail.Ordered;
            PurchaseOrderDetailEntity.CreatedBy = purchaseOrderDetail.IdUser;

            PurchaseOrderDetails.Add(PurchaseOrderDetailEntity);
        }

        await _PurchaseOrderDetailRepository.CreatePurchaseOrderDetailAsync(PurchaseOrderDetails);

        return PurchaseOrderDetails.Count;
    }
}
