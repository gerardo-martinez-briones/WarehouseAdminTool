using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Contracts.Wpf;
using Core.Features.PurchaseOrders.Queries.GetPurchaseOrders;
using Core.Features.PurchaseOrderStatusLogs.Queries.GetLastStatus;
using Core.Features.Trackings.Queries.GetProgressPercentage;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using Wpf.Services;

namespace Wpf.ViewModels;

public partial class SearchPurchaseOrdersViewModel : ObservableObject
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<SearchPurchaseOrdersViewModel> _logger;
    private readonly IMediator _mediator;
    private readonly Helper _helper;

    public SearchPurchaseOrdersViewModel(
        IConfiguration configuration,
        ILogger<SearchPurchaseOrdersViewModel> logger,
        IMediator mediator,
        Helper helper)
    {
        _configuration = configuration;
        _logger = logger;
        _mediator = mediator;
        _helper = helper;
    }

    public event EventHandler<int> OnEditPurchaseOrder;
    public event EventHandler<int> OnOpenTracking;

    [ObservableProperty]
    private string filter = string.Empty;

    [ObservableProperty]
    private ObservableCollection<IPurchaseOrderModel> purchaseOrders = new();

    [RelayCommand]
    private async Task SearchPurchaseOrders()
    {
        try
        {
            PurchaseOrders.Clear();

            var getPurchaseOrdersQuery = new GetPurchaseOrdersQuery();
            
            getPurchaseOrdersQuery.Filter = Filter;

            var getPurchaseOrdersResponse = await _mediator.Send(getPurchaseOrdersQuery);

            foreach (var purchaseOrderItem in getPurchaseOrdersResponse)
            {
                var purchaseOrder = App.WpfHost.Services.GetRequiredService<IPurchaseOrderModel>();

                purchaseOrder.IdPurchaseOrder = purchaseOrderItem.IdPurchaseOrder;
                purchaseOrder.IdUser = purchaseOrderItem.CreatedBy;
                purchaseOrder.CustomerPO = purchaseOrderItem.CustomerPO;
                purchaseOrder.CustomerName = purchaseOrderItem.CustomerName;
                purchaseOrder.OrderDate = purchaseOrderItem.OrderDate.ToShortDateString();
                purchaseOrder.OrderNumber = purchaseOrderItem.OrderNumber;
                purchaseOrder.ReqShipDate = purchaseOrderItem.ReqShipDate.ToShortDateString();
                purchaseOrder.Comments = purchaseOrderItem.Comments;

                var getLastStatusQuery = new GetLastStatusQuery();
                var getProgressPercentageQuery = new GetProgressPercentageQuery();

                getLastStatusQuery.IdPurchaseOrder = purchaseOrder.IdPurchaseOrder;
                getProgressPercentageQuery.IdPurchaseOrder = purchaseOrder.IdPurchaseOrder;

                var getLastStatusQueryResponse = await _mediator.Send(getLastStatusQuery);
                var getProgressPercentageResponse = await _mediator.Send(getProgressPercentageQuery);

                purchaseOrder.Status = getLastStatusQueryResponse.StatusName;
                purchaseOrder.Progress = Math.Truncate(getProgressPercentageResponse);

                PurchaseOrders.Add(purchaseOrder);
            }
        }
        catch (Exception ex)
        {
            _helper.ShowError(ex);
            _helper.SetLogError(ex);
        }
    }

    [RelayCommand]
    private void EditPurchaseOrder(object value)
    {
        OnEditPurchaseOrder(this, int.Parse(value.ToString()));
    }

    [RelayCommand]
    private void OpenTracking(object value)
    {
        OnOpenTracking(this, int.Parse(value.ToString()));
    }
}