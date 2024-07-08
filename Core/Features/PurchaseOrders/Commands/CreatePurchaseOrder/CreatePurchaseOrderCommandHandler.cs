using Core.Contracts.Persistence;
using Domain;
using MediatR;

namespace Core.Features.PurchaseOrders.Commands.CreatePurchaseOrder;

public class CreatePurchaseOrderCommandHandler : IRequestHandler<CreatePurchaseOrderCommand, int>
{
    private readonly IPurchaseOrderRepository _purchaseOrderRepository;

    public CreatePurchaseOrderCommandHandler(IPurchaseOrderRepository purchaseOrderRepository)
    {
        _purchaseOrderRepository = purchaseOrderRepository;
    }

    public async Task<int> Handle(CreatePurchaseOrderCommand request, CancellationToken cancellationToken)
    {
        PurchaseOrder purchaseOrder = new();

        purchaseOrder.CreatedBy = request.IdUser;
        purchaseOrder.OrderNumber = request.OrderNumber;
        purchaseOrder.OrderDate = request.OrderDate;
        purchaseOrder.ReqShipDate = request.ReqShipDate;
        purchaseOrder.CustomerPO = request.CustomerPO;
        purchaseOrder.CustomerName = request.CustomerName;
        purchaseOrder.Comments = request.Comments;

        var response = await _purchaseOrderRepository.CreatePurchaseOrderAsync(purchaseOrder);

        return response;
    }
}
