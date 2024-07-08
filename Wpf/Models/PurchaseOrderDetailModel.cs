using CommunityToolkit.Mvvm.ComponentModel;
using Core.Contracts.Wpf;

namespace Wpf.Models;

public partial class PurchaseOrderDetailModel : ObservableObject, IPurchaseOrderDetailModel
{
    [ObservableProperty]
    private int idPurchaseOrderDetail;

    [ObservableProperty]
    private int idPurchaseOrder;

    [ObservableProperty]
    private int idUser;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Edited))]
    private string sKU;

    [ObservableProperty]
    private string itemNumber;

    [ObservableProperty]
    private string itemDescription;

    [ObservableProperty]
    private string unit;

    [ObservableProperty]
    private int ordered;

    [ObservableProperty]
    private bool edited = false;

    partial void OnSKUChanged(string oldValue, string newValue)
    {
        if (oldValue != null)
            Edited = !oldValue.Equals(newValue);
    }
}