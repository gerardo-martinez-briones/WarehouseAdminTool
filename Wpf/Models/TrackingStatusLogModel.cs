using CommunityToolkit.Mvvm.ComponentModel;
using Core.Contracts.Wpf;

namespace Wpf.Models;

public partial class TrackingStatusLogModel : ObservableObject, ITrackingStatusLogModel
{
    [ObservableProperty]
    private int idTrackingStatusLog;

    [ObservableProperty]
    private int idPurchaseOrder;

    [ObservableProperty]
    private string hostName;

    [ObservableProperty]
    private string palletNumber;

    [ObservableProperty]
    private string bedNumber;

    [ObservableProperty]
    private bool isCompleted;
}