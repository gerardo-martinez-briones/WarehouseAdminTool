using Core.Contracts.Wpf;
using MediatR;
using System.Collections.ObjectModel;

namespace Core.Features.PurchaseOrderDetails.Commands.UpdatePurchaseOrderDetail;

public class UpdatePurchaseOrderDetailCommand : IRequest<int>
{
    public ObservableCollection<IPurchaseOrderDetailModel> PurchaseOrderDetails { get; set; }
    public int EditedBy { get; set; }
    public DateTime EditedAt { get; set; }
}