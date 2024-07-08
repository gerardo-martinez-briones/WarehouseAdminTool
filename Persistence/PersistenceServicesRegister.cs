using Core.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServicesRegister
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SQLConnection")));

        services.AddScoped<IPurchaseOrderDetailRepository, PurchaseOrderDetailRepository>();
        services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
        services.AddScoped<IPurchaseOrderStatusLogRepository, PurchaseOrderStatusLogRepository>();
        services.AddScoped<ITrackingRepository, TrackingRepository>();
        services.AddScoped<ITrackingStatusLogRepository, TrackingStatusLogRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}