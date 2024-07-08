using Core;
using Core.Contracts.Wpf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Wpf.Models;
using Wpf.Services;
using Wpf.ViewModels;
using Wpf.Views;

namespace Wpf.Startup;

public static class ServiceExtensions
{
    public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCoreServices();
        services.AddPersistenceServices(configuration);

        services.AddSingleton<ILoginModel, LoginModel>();
        services.AddSingleton<Helper>();

        services.AddTransient<IPurchaseOrderDetailModel, PurchaseOrderDetailModel>();
        services.AddTransient<IPurchaseOrderModel, PurchaseOrderModel>();
        services.AddTransient<IReviewedUserModel, ReviewedUserModel>();
        services.AddTransient<ITrackingModel, TrackingModel>();
        services.AddTransient<ITrackingStatusLogModel, TrackingStatusLogModel>();

        services.AddSingleton<LoginViewModel>();
        services.AddSingleton<LoginView>();

        services.AddTransient<EditPurchaseOrderViewModel>();
        services.AddTransient<EditPurchaseOrderView>();

        services.AddTransient<SearchPurchaseOrdersViewModel>();
        services.AddTransient<SearchPurchaseOrdersView>();

        services.AddTransient<TrackingPurchaseOrderViewModel>();
        services.AddTransient<TrackingPurchaseOrderView>();

        services.AddTransient<UploadPurchaseOrderViewModel>();
        services.AddTransient<UploadPurchaseOrderView>();

        services.AddSingleton<HomeViewModel>();
        services.AddSingleton<HomeView>();
    }
}