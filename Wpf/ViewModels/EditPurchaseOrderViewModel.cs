using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Contracts.Wpf;
using Core.Features.PurchaseOrderDetails.Commands.UpdatePurchaseOrderDetail;
using Core.Features.PurchaseOrderDetails.Queries.GetPurchaseOrderDetails;
using Core.Features.PurchaseOrders.Commands.CreatePurchaseOrder;
using Core.Features.PurchaseOrders.Queries.GetPurchaseOrder;
using Core.Features.PurchaseOrders.Queries.GetPurchaseOrders;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.LayoutRenderers.Wrappers;
using System.Collections.ObjectModel;
using Wpf.Services;

namespace Wpf.ViewModels;

public partial class EditPurchaseOrderViewModel : ObservableObject
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<EditPurchaseOrderViewModel> _logger;
    private readonly IMediator _mediator;
    private readonly Helper _helper;

    public EditPurchaseOrderViewModel(
        IConfiguration configuration,
        ILogger<EditPurchaseOrderViewModel> logger,
        IMediator mediator,
        Helper helper)
    {
        _configuration = configuration;
        _logger = logger;
        _mediator = mediator;
        _helper = helper;
    }

    public event EventHandler OnClose;

    [ObservableProperty]
    private string filter = string.Empty;

    [ObservableProperty]
    private string dynamicTitle = string.Empty;

    [ObservableProperty]
    private int idPurchaseOrder;

    [ObservableProperty]
    ObservableCollection<IPurchaseOrderDetailModel> purchaseOrderDetails = new();

    [RelayCommand]
    private async Task LoadPurchaseOrder()
    {
        try
        {
            var getPurchaseOrderQuery = new GetPurchaseOrderQuery();

            getPurchaseOrderQuery.IdPurchaseOrder = IdPurchaseOrder;

            var getPurchaseOrderResponse = await _mediator.Send(getPurchaseOrderQuery);

            DynamicTitle = $"No. Orden del Cliente {getPurchaseOrderResponse.CustomerPO} - No. Orden Interno {getPurchaseOrderResponse.OrderNumber}";

            await SearchPurchaseOrderDetails();
        }
        catch (Exception ex)
        {
            _helper.ShowError(ex);
            _helper.SetLogError(ex);
        }
    }

    [RelayCommand]
    private async Task SearchPurchaseOrderDetails()
    {
        try
        {
            var getPurchaseOrderDetailsQuery = new GetPurchaseOrderDetailsQuery();

            getPurchaseOrderDetailsQuery.IdPurchaseOrder = IdPurchaseOrder;
            getPurchaseOrderDetailsQuery.Filter = Filter;

            var getPurchaseOrderDetailsResponse = await _mediator.Send(getPurchaseOrderDetailsQuery);

            PurchaseOrderDetails.Clear();

            foreach (var purchaseOrderDetailResponse in getPurchaseOrderDetailsResponse)
            {
                var purchaseOrderDetail = App.WpfHost.Services.GetRequiredService<IPurchaseOrderDetailModel>();

                purchaseOrderDetail.IdPurchaseOrderDetail = purchaseOrderDetailResponse.IdPurchaseOrderDetail;
                purchaseOrderDetail.IdPurchaseOrder = purchaseOrderDetailResponse.IdPurchaseOrder;
                purchaseOrderDetail.SKU = purchaseOrderDetailResponse.SKU;
                purchaseOrderDetail.ItemNumber = purchaseOrderDetailResponse.ItemNumber;
                purchaseOrderDetail.ItemDescription = purchaseOrderDetailResponse.ItemDescription;
                purchaseOrderDetail.Unit = purchaseOrderDetailResponse.Unit;
                purchaseOrderDetail.Ordered = purchaseOrderDetailResponse.Ordered;

                PurchaseOrderDetails.Add(purchaseOrderDetail);
            }
        }
        catch (Exception ex)
        {
            _helper.ShowError(ex);
            _helper.SetLogError(ex);
        }
    }

    [RelayCommand]
    private async Task UpdatePurchaseOrderDetails()
    {
        try
        {
            var purchaseOrderDetailsEdited = PurchaseOrderDetails.Where(x => x.Edited == true).ToList();

            var updatePurchaseOrderDetailCommand = new UpdatePurchaseOrderDetailCommand();

            updatePurchaseOrderDetailCommand.PurchaseOrderDetails = new ObservableCollection<IPurchaseOrderDetailModel>(purchaseOrderDetailsEdited);
            updatePurchaseOrderDetailCommand.EditedBy = App.WpfHost.Services.GetRequiredService<ILoginModel>().IdUser;
            updatePurchaseOrderDetailCommand.EditedAt = DateTime.Now;

            var updatePurchaseOrderDetailResponse = await _mediator.Send(updatePurchaseOrderDetailCommand);

            await SearchPurchaseOrderDetails();
        }
        catch (Exception ex)
        {
            _helper.ShowError(ex);
            _helper.SetLogError(ex);
        }
    }

    [RelayCommand]
    private void Close()
    {
        try
        {
            OnClose(this, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            _helper.ShowError(ex);
            _helper.SetLogError(ex);
        }
    }
}