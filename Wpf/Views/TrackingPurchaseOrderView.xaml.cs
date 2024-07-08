using System.Windows.Controls;
using System.Windows.Input;
using Wpf.ViewModels;

namespace Wpf.Views;

public partial class TrackingPurchaseOrderView : UserControl
{
    public TrackingPurchaseOrderView()
    {
        InitializeComponent();
    }

    private async void TxtScanData_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
            await ((TrackingPurchaseOrderViewModel)DataContext).ScanData(TxtScanData.Text.Trim());
    }
}