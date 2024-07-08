using Core.Contracts.Wpf;
using MediatR;
using System.Collections.ObjectModel;

namespace Core.Features.PurchaseOrderDetails.Commands.CreatePurchaseOrderDetail;

public class CreatePurchaseOrderDetailCommand : IRequest<int>
{
    public ObservableCollection<IPurchaseOrderDetailModel> PurchaseOrderDetails { get; set; }
}
