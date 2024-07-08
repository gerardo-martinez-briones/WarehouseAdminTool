using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Contracts.Wpf;
using Core.Features.PurchaseOrderDetails.Commands.CreatePurchaseOrderDetail;
using Core.Features.PurchaseOrders.Commands.CreatePurchaseOrder;
using Core.Features.PurchaseOrderStatusLogs.Commands.CreatePurchaseOrderStatusLog;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using Wpf.Services;

namespace Wpf.ViewModels;

public partial class UploadPurchaseOrderViewModel : ObservableObject
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<UploadPurchaseOrderViewModel> _logger;
    private readonly IMediator _mediator;
    private readonly Helper _helper;

    public UploadPurchaseOrderViewModel(
        IConfiguration configuration,
        ILogger<UploadPurchaseOrderViewModel> logger,
        IMediator mediator,
        Helper helper)
    {
        _configuration = configuration;
        _logger = logger;
        _mediator = mediator;
        _helper = helper;
    }

    [ObservableProperty]
    private string fileNameSelected = null;

    [ObservableProperty]
    private IPurchaseOrderModel purchaseOrder = App.WpfHost.Services.GetRequiredService<IPurchaseOrderModel>();

    [ObservableProperty]
    private ObservableCollection<IPurchaseOrderDetailModel> purchaseOrderDetails = new();

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CreateCommand))]
    private string totalItems;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CreateCommand))]
    private bool canCreate = false;

    [RelayCommand]
    private void Upload()
    {
        try
        {
            var openFileDialog = new OpenFileDialog { Filter = "Csv files (*.csv)|*.csv" };

            Nullable<bool> success = openFileDialog.ShowDialog();

            if (success == true)
            {
                ClearPurchaseOrder();

                var fileName = openFileDialog.FileName;

                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    FileNameSelected = fileName;

                    ReadFile(fileName);
                }
            }
        }
        catch (Exception ex)
        {
            _helper.ShowError(ex);
            _helper.SetLogError(ex);
        }
    }

    [RelayCommand(CanExecute = nameof(CanCreate))]
    private async Task Create()
    {
        try
        {
            var createPurchaseOrderCommand = new CreatePurchaseOrderCommand();

            createPurchaseOrderCommand.IdUser = App.WpfHost.Services.GetRequiredService<ILoginModel>().IdUser;
            createPurchaseOrderCommand.OrderNumber = PurchaseOrder.OrderNumber;
            createPurchaseOrderCommand.OrderDate = DateTime.Parse(PurchaseOrder.OrderDate);
            createPurchaseOrderCommand.ReqShipDate = DateTime.Parse(PurchaseOrder.ReqShipDate);
            createPurchaseOrderCommand.CustomerPO = PurchaseOrder.CustomerPO;
            createPurchaseOrderCommand.CustomerName = PurchaseOrder.CustomerName;
            createPurchaseOrderCommand.Comments = PurchaseOrder.Comments;

            var createPurchaseOrderResponse = await _mediator.Send(createPurchaseOrderCommand);

            if (createPurchaseOrderResponse > 0)
            {
                var createPurchaseOrderStatusLogCommand = new CreatePurchaseOrderStatusLogCommand();

                createPurchaseOrderStatusLogCommand.IdPurchaseOrder = createPurchaseOrderResponse;
                createPurchaseOrderStatusLogCommand.IdStatus = 1; // Creada.
                createPurchaseOrderStatusLogCommand.IdUser = createPurchaseOrderCommand.IdUser;

                var createPurchaseOrderStatusLogResponse = await _mediator.Send(createPurchaseOrderStatusLogCommand);

                if (createPurchaseOrderStatusLogResponse > 0)
                {
                    var createPurchaseOrderDetailCommand = new CreatePurchaseOrderDetailCommand();

                    PurchaseOrderDetails.ToList().ForEach(x => x.IdPurchaseOrder = createPurchaseOrderResponse);
                    PurchaseOrderDetails.ToList().ForEach(x => x.IdUser = createPurchaseOrderCommand.IdUser);

                    createPurchaseOrderDetailCommand.PurchaseOrderDetails = PurchaseOrderDetails;

                    var createPurchaseOrderDetailResponse = await _mediator.Send(createPurchaseOrderDetailCommand);

                    if (createPurchaseOrderDetailResponse > 0)
                        _helper.ShowInformation($"¡La Orden de Compra {PurchaseOrder.CustomerPO} se Procesó Correctamente!");
                }
            }

            ClearPurchaseOrder();
        }
        catch (Exception ex)
        {
            _helper.ShowError(ex);
            _helper.SetLogError(ex);
            ClearPurchaseOrder();
        }
    }

    partial void OnTotalItemsChanged(string value)
    {
        CanCreate = !string.IsNullOrWhiteSpace(value);
    }

    public void ReadFile(string fileName)
    {
        using (var reader = new StreamReader(fileName))
        {
            var currentLine = string.Empty;

            while ((currentLine = reader.ReadLine()) != null)
            {
                if (currentLine.IndexOf("CODE ", StringComparison.CurrentCultureIgnoreCase) >= 0)
                {
                    string[] detail = Regex.Split(currentLine, "[,]{1}(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

                    if (detail.Length > 5)
                    {
                        if (detail[1] != "" || detail[2] != "")
                        {
                            var purchaseOrderDetail = App.WpfHost.Services.GetRequiredService<IPurchaseOrderDetailModel>();

                            purchaseOrderDetail.SKU = detail[1].Replace('"', ' ').Trim();
                            purchaseOrderDetail.ItemNumber = detail[2].Replace('"', ' ').Trim();
                            purchaseOrderDetail.ItemDescription = detail[3].Replace('"', ' ').Trim();
                            purchaseOrderDetail.Unit = detail[4].Replace('"', ' ').Trim();
                            purchaseOrderDetail.Ordered = int.TryParse(detail[5].Replace('"', ' ').Trim(), out _) ? int.Parse(detail[5]) : 0;

                            PurchaseOrderDetails.Add(purchaseOrderDetail);
                        }
                    }
                }
                else
                {
                    string[] header = currentLine.Split(",");
                    int index = -1;

                    index = Array.IndexOf(header, "\"Order Date:\"");
                    PurchaseOrder.OrderDate = (index >= 0 ? header[index + 1].Replace('"', ' ').Trim() : PurchaseOrder.OrderDate);

                    index = Array.IndexOf(header, "\"Order No: \"");
                    PurchaseOrder.OrderNumber = (index >= 0 ? header[index + 1].Replace('"', ' ').Trim() : PurchaseOrder.OrderNumber);

                    index = Array.IndexOf(header, "\"Req'd Ship Date:\"");
                    PurchaseOrder.ReqShipDate = (index >= 0 ? header[index + 1].Replace('"', ' ').Trim() : PurchaseOrder.ReqShipDate);

                    index = Array.IndexOf(header, "\"Sold To:\"");
                    PurchaseOrder.CustomerName = (index >= 0 ? header[index + 1].Replace('"', ' ').Trim() : PurchaseOrder.CustomerName);

                    index = Array.IndexOf(header, "\"Cust. P.O.:\"");
                    PurchaseOrder.CustomerPO = (index >= 0 ? header[index + 1].Replace('"', ' ').Trim() : PurchaseOrder.CustomerPO);

                    index = Array.IndexOf(header, "\"Comments:\"");
                    PurchaseOrder.Comments = (index >= 0 ? header[index + 1].Replace('"', ' ').Trim() : PurchaseOrder.Comments);
                }
            }

            TotalItems = PurchaseOrderDetails.Count > 0 ? PurchaseOrderDetails.Count.ToString() : string.Empty;

            if (string.IsNullOrWhiteSpace(PurchaseOrder.CustomerPO)
                || string.IsNullOrWhiteSpace(PurchaseOrder.OrderNumber)
                || string.IsNullOrWhiteSpace(PurchaseOrder.CustomerName))
            {
                throw new Exception($"El archivo {FileNameSelected} es invalido.");
            }
        }
    }

    private void ClearPurchaseOrder()
    {
        PurchaseOrder = App.WpfHost.Services.GetRequiredService<IPurchaseOrderModel>();
        PurchaseOrderDetails.Clear();
        FileNameSelected = string.Empty;
        TotalItems = string.Empty;
    }
}