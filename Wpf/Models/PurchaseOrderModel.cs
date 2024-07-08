using CommunityToolkit.Mvvm.ComponentModel;
using Core.Contracts.Wpf;

namespace Wpf.Models;

public partial class PurchaseOrderModel : ObservableObject, IPurchaseOrderModel
{
    [ObservableProperty]
    private int idPurchaseOrder;

    [ObservableProperty]
    private int idUser;

    [ObservableProperty]
    private string orderNumber;

    [ObservableProperty]
    private string orderDate;

    [ObservableProperty]
    private string reqShipDate;

    [ObservableProperty]
    private string customerPO;

    [ObservableProperty]
    private string customerName;

    [ObservableProperty]
    private string comments;

    [ObservableProperty]
    private string status;

    [ObservableProperty]
    private double progress;
}
