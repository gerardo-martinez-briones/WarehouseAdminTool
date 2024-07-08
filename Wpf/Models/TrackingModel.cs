using CommunityToolkit.Mvvm.ComponentModel;
using Core.Contracts.Wpf;

namespace Wpf.Models;

public partial class TrackingModel : ObservableObject, ITrackingModel
{
    [ObservableProperty]
    private int idTracking;

    [ObservableProperty]
    private int idPurchaseOrderDetail;

    [ObservableProperty]
    private string hostName;

    [ObservableProperty]
    private string orderNumber;

    [ObservableProperty]
    private string sKU;

    [ObservableProperty]
    private string itemNumber;

    [ObservableProperty]
    private string palletNumber;

    [ObservableProperty]
    private string bedNumber;

    [ObservableProperty]
    private int createdBy;

    [ObservableProperty]
    private int reviewedBy;

    [ObservableProperty]
    private string createdAt;
}