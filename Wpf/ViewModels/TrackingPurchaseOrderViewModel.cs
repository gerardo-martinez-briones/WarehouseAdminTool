using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Contracts.Wpf;
using Core.Features.PurchaseOrderDetails.Queries.GetPurchaseOrderDetails;
using Core.Features.PurchaseOrders.Queries.GetPurchaseOrder;
using Core.Features.Trackings.Commands.CreateTracking;
using Core.Features.Trackings.Queries.GetCountTrackings;
using Core.Features.Trackings.Queries.GetProgressPercentage;
using Core.Features.TrackingStatusLogs.Queries.GetLastPalletAndBed;
using Core.Features.Users.Queries.GetUsers;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using Wpf.Services;

namespace Wpf.ViewModels;

public partial class TrackingPurchaseOrderViewModel : ObservableObject
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<TrackingPurchaseOrderViewModel> _logger;
    private readonly IMediator _mediator;
    private readonly Helper _helper;

    public TrackingPurchaseOrderViewModel(
        IConfiguration configuration,
        ILogger<TrackingPurchaseOrderViewModel> logger,
        IMediator mediator,
        Helper helper)
    {
        _configuration = configuration;
        _logger = logger;
        _mediator = mediator;
        _helper = helper;

        FullName = App.WpfHost.Services.GetRequiredService<ILoginModel>().FullName;
    }

    [ObservableProperty]
    private IPurchaseOrderModel purchaseOrder = App.WpfHost.Services.GetRequiredService<IPurchaseOrderModel>();

    [ObservableProperty]
    private ObservableCollection<IPurchaseOrderDetailModel> purchaseOrderDetails = new();

    [ObservableProperty]
    private ObservableCollection<IReviewedUserModel> reviewedUsers = new();

    [ObservableProperty]
    private IReviewedUserModel reviewedUserSelected = null;

    [ObservableProperty]
    private ITrackingStatusLogModel trackingStatusLog = App.WpfHost.Services.GetRequiredService<ITrackingStatusLogModel>();

    [ObservableProperty]
    private int idPurchaseOrder;

    [ObservableProperty]
    private string dynamicTitle = string.Empty;

    [ObservableProperty]
    private string fullName = string.Empty;

    [ObservableProperty]
    private double totalOrderedItems;

    [ObservableProperty]
    private double totalTrackingItems;
    
    [ObservableProperty]
    private double progressValue;

    [ObservableProperty]
    private string itemNumber;

    [ObservableProperty]
    private string itemDescription;

    [ObservableProperty]
    private bool canScan = false;

    [RelayCommand]
    private async Task LoadInformation()
    {
        try
        {
            var getPurchaseOrderQuery = new GetPurchaseOrderQuery();

            getPurchaseOrderQuery.IdPurchaseOrder = IdPurchaseOrder;

            var getPurchaseOrderResponse = await _mediator.Send(getPurchaseOrderQuery);

            if (getPurchaseOrderResponse != null)
            {
                PurchaseOrder.IdPurchaseOrder = getPurchaseOrderResponse.IdPurchaseOrder;
                PurchaseOrder.OrderNumber = getPurchaseOrderResponse.OrderNumber;
                PurchaseOrder.OrderDate = getPurchaseOrderResponse.OrderDate.ToShortDateString();
                PurchaseOrder.ReqShipDate = getPurchaseOrderResponse.ReqShipDate.ToShortDateString();
                PurchaseOrder.CustomerPO = getPurchaseOrderResponse.CustomerPO;
                PurchaseOrder.CustomerName = getPurchaseOrderResponse.CustomerName;
                PurchaseOrder.Comments = getPurchaseOrderResponse.Comments;

                DynamicTitle = $"Preparando la Orden del Cliente {PurchaseOrder.CustomerPO} - No. Orden Interno {PurchaseOrder.OrderNumber}";
                TotalOrderedItems = getPurchaseOrderResponse.PurchaseOrderDetails.Sum(x => x.Ordered);

                var getPurchaseOrderDetailsQuery = new GetPurchaseOrderDetailsQuery();

                getPurchaseOrderDetailsQuery.IdPurchaseOrder = IdPurchaseOrder;

                var getPurchaseOrderDetailsResponse = await _mediator.Send(getPurchaseOrderDetailsQuery);

                if(getPurchaseOrderDetailsResponse != null)
                {
                    foreach (var getPurchaseOrderDetailsItem in getPurchaseOrderDetailsResponse)
                    {
                        var purchaseOrderDetail = App.WpfHost.Services.GetRequiredService<IPurchaseOrderDetailModel>();

                        purchaseOrderDetail.IdPurchaseOrderDetail = getPurchaseOrderDetailsItem.IdPurchaseOrderDetail;
                        purchaseOrderDetail.IdPurchaseOrder = getPurchaseOrderDetailsItem.IdPurchaseOrder;
                        purchaseOrderDetail.SKU = getPurchaseOrderDetailsItem.SKU;
                        purchaseOrderDetail.ItemNumber = getPurchaseOrderDetailsItem.ItemNumber;
                        purchaseOrderDetail.ItemDescription = getPurchaseOrderDetailsItem.ItemDescription;
                        purchaseOrderDetail.Unit = getPurchaseOrderDetailsItem.Unit;
                        purchaseOrderDetail.Ordered = getPurchaseOrderDetailsItem.Ordered;

                        PurchaseOrderDetails.Add(purchaseOrderDetail);
                    }
                }
            }

            await LoadReviewedCombo();
        }
        catch (Exception ex)
        {
            _helper.ShowError(ex);
            _helper.SetLogError(ex);
        }
    }

    [RelayCommand]
    private async Task LoadReviewedCombo()
    {
        try
        {
            var getUsersQuery = new GetUsersQuery();

            var getUsersResponse = await _mediator.Send(getUsersQuery);

            if (getUsersResponse != null)
            {
                foreach (var getUsersItem in getUsersResponse)
                {
                    var reviewedUser = App.WpfHost.Services.GetRequiredService<IReviewedUserModel>();

                    reviewedUser.IdUser = getUsersItem.IdUser;
                    reviewedUser.FullName = $"{getUsersItem.FirstName} {getUsersItem.LastName}";

                    ReviewedUsers.Add(reviewedUser);
                }
            }

            await LoadBackgroundProcess();
        }
        catch (Exception ex)
        {
            _helper.ShowError(ex);
            _helper.SetLogError(ex);
        }
    }

    [RelayCommand]
    private async Task LoadBackgroundProcess()
    {
        BackgroundWorker worker = new();

        worker.DoWork += OnBackgroundProcess_DoWork;

        worker.RunWorkerAsync();
    }

    private async void OnBackgroundProcess_DoWork(object sender, DoWorkEventArgs e)
    {
        var getProgressPercentageQuery = new GetProgressPercentageQuery();

        getProgressPercentageQuery.IdPurchaseOrder = IdPurchaseOrder;

        while (true)
        {
            ProgressValue = await _mediator.Send(getProgressPercentageQuery);
            ProgressValue = Math.Truncate(ProgressValue);

            var getCountTrackingsQuery = new GetCountTrackingsQuery();

            getCountTrackingsQuery.IdPurchaseOrder += IdPurchaseOrder;

            TotalTrackingItems = await _mediator.Send(getCountTrackingsQuery);

            Thread.Sleep(1000);
        }
    }

    [RelayCommand]
    private async Task StartTracking()
    {
        try
        {
            var getLastPalletAndBedQuery = new GetLastPalletAndBedQuery();

            getLastPalletAndBedQuery.IdPurchaseOrder = IdPurchaseOrder;
            getLastPalletAndBedQuery.HostName = Dns.GetHostName();
            getLastPalletAndBedQuery.IdUser = App.WpfHost.Services.GetRequiredService<ILoginModel>().IdUser;

            var getLastPalletAndBedResponse = await _mediator.Send(getLastPalletAndBedQuery);

            if (getLastPalletAndBedResponse != null)
            {
                TrackingStatusLog.IdTrackingStatusLog = getLastPalletAndBedResponse.IdTrackingStatusLog;
                TrackingStatusLog.IdPurchaseOrder = getLastPalletAndBedResponse.IdPurchaseOrder;
                TrackingStatusLog.HostName = getLastPalletAndBedResponse.HostName;
                TrackingStatusLog.PalletNumber = getLastPalletAndBedResponse.PalletNumber.ToString();
                TrackingStatusLog.BedNumber = getLastPalletAndBedResponse.BedNumber.ToString();
                TrackingStatusLog.IsCompleted = getLastPalletAndBedResponse.IsCompleted;
            }

            CanScan = true;
        }
        catch (Exception ex)
        {
            _helper.ShowError(ex);
            _helper.SetLogError(ex);
        }
    }

    public async Task ScanData(string sku)
    {
        var data = PurchaseOrderDetails.Where(x => x.SKU.Equals(sku)).FirstOrDefault();

        if (data != null)
        {
            ItemNumber = data.ItemNumber;
            ItemDescription = data.ItemDescription;

            var createTrackingCommand = new CreateTrackingCommand();

            createTrackingCommand.IdPurchaseOrderDetail = data.IdPurchaseOrderDetail;
            createTrackingCommand.HostName = Dns.GetHostName();
            createTrackingCommand.OrderNumber = PurchaseOrder.OrderNumber;
            createTrackingCommand.SKU = data.SKU;
            createTrackingCommand.ItemNumber = data.ItemNumber;
            createTrackingCommand.PalletNumber = byte.Parse(TrackingStatusLog.PalletNumber);
            createTrackingCommand.BedNumber = byte.Parse(TrackingStatusLog.BedNumber);
            createTrackingCommand.CreatedBy = App.WpfHost.Services.GetRequiredService<ILoginModel>().IdUser;
            createTrackingCommand.ReviewedBy = ReviewedUserSelected.IdUser;

            var createTrackingResponse = await _mediator.Send(createTrackingCommand);
        }
    }
}