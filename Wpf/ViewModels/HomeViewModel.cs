using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Contracts.Wpf;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Wpf.Services;
using Wpf.Views;

namespace Wpf.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly ILogger<HomeViewModel> _logger;
    private readonly ILoginModel _login;
    private readonly Helper _helper;

    public HomeViewModel(
        ILogger<HomeViewModel> logger,
        ILoginModel login,
        Helper helper)
    {
        _logger = logger;
        _login = login;
        this._helper = helper;
        BuildMenuBar();

        FullName = _login.FullName.ToUpper();
    }

    [ObservableProperty]
    private string fullName;

    [ObservableProperty]
    ObservableCollection<MenuItem> _dynamicMenu = null;

    [ObservableProperty]
    ObservableObject _dynamicView = null;

    private void BuildMenuBar()
    {
        DynamicMenu = new ObservableCollection<MenuItem>();

        var menuPurchaseOrders = new MenuItem();
        var menuImportFile = new MenuItem();
        var menuPurchaseOrderList = new MenuItem();

        var menuReports = new MenuItem();

        var menuConfiguration = new MenuItem();
        var menuUserManager = new MenuItem();

        menuPurchaseOrders.Header = "Ordenes de Compra";

        menuImportFile.Header = "Cargar Orden (.csv)";
        menuImportFile.Command = UploadPurchaseOrderCommand;

        menuPurchaseOrderList.Header = "Buscar Ordenes";
        menuPurchaseOrderList.Command = SearchPurchaseOrdersCommand;

        menuPurchaseOrders.Items.Add(menuImportFile);
        menuPurchaseOrders.Items.Add(menuPurchaseOrderList);

        menuReports.Header = "Reportes";

        menuConfiguration.Header = "Configuraciones";
        menuUserManager.Header = "Administrador de Usuarios";
        menuUserManager.Command = UserManagerCommand;

        menuConfiguration.Items.Add(menuUserManager);

        DynamicMenu.Add(menuPurchaseOrders);
        DynamicMenu.Add(menuReports);
        DynamicMenu.Add(menuConfiguration);
    }

    [RelayCommand]
    private void UploadPurchaseOrder()
    {
        try
        {
            DynamicView = null;
            DynamicView = App.WpfHost.Services.GetRequiredService<UploadPurchaseOrderViewModel>();
        }
        catch (Exception ex)
        {
            _helper.ShowError(ex);
            _helper.SetLogError(ex);
        }
    }

    [RelayCommand]
    private void SearchPurchaseOrders()
    {
        try
        {
            var vm = App.WpfHost.Services.GetRequiredService<SearchPurchaseOrdersViewModel>();

            vm.OnEditPurchaseOrder += OnEditPurchaseOrder;
            vm.OnOpenTracking += OnOpenTracking;

            DynamicView = null;
            DynamicView = vm;
        }
        catch (Exception ex)
        {
            _helper.ShowError(ex);
            _helper.SetLogError(ex);
        }
    }

    [RelayCommand]
    private void UserManager()
    {
        try
        {
            DynamicView = null;
            //DynamicView = App.WpfHost.Services.GetRequiredService<UserManagerViewModel>();
        }
        catch (Exception ex)
        {
            _helper.ShowError(ex);
            _helper.SetLogError(ex);
        }
    }

    private void OnEditPurchaseOrder(object sender, int e)
    {
        try
        {
            var vm = App.WpfHost.Services.GetRequiredService<EditPurchaseOrderViewModel>();

            vm.IdPurchaseOrder = e;
            vm.OnClose += OnClose;

            DynamicView = null;
            DynamicView = vm;
        }
        catch (Exception ex)
        {
            _helper.ShowError(ex);
            _helper.SetLogError(ex);
        }
    }

    private void OnOpenTracking(object sender, int e)
    {
        try
        {
            var vm = App.WpfHost.Services.GetRequiredService<TrackingPurchaseOrderViewModel>();

            vm.IdPurchaseOrder = e;

            DynamicView = null;
            DynamicView = vm;
        }
        catch (Exception ex)
        {
            _helper.ShowError(ex);
            _helper.SetLogError(ex);
        }
    }

    private void OnClose(object sender, EventArgs e)
    {
        try
        {
            SearchPurchaseOrders();
        }
        catch (Exception ex)
        {
            _helper.ShowError(ex);
            _helper.SetLogError(ex);
        }
    }
}