using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System.Windows;
using Wpf.Startup;
using Wpf.Views;

namespace Wpf;

public partial class App : Application
{
    public static IHost WpfHost { get; private set; }

    public App()
    {
        WpfHost = new HostBuilder().ConfigureServices((context, services) =>
        {
            services.AddCustomServices(context.Configuration);
        }).ConfigureAppConfiguration((context, configuration) =>
        {
            configuration.SetBasePath(context.HostingEnvironment.ContentRootPath);
            configuration.AddJsonFile("appsettings.json", optional: false);
        }).ConfigureLogging(logger =>
        {
            logger.ClearProviders();
            logger.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
            logger.AddNLog("Nlog.config");
        }).Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        await WpfHost.StartAsync();

        var login = App.WpfHost.Services.GetRequiredService<LoginView>();

        login.Show();
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);
        await WpfHost.StopAsync();
    }
}