using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;
using System.Windows;

namespace Wpf.Services;

public class Helper
{
    private readonly string _title;
    private readonly ILogger<Helper> _logger;

    public Helper(ILogger<Helper> logger)
    {
        _title = $"{Process.GetCurrentProcess().ProcessName} {Assembly.GetExecutingAssembly().GetName().Version}";

        _logger = logger;
    }

    public void SetLogError(Exception ex)
    {
        try
        {
            _logger.LogError(ex.Message, null);
        }
        catch { }
    }

    public void ShowError(Exception ex)
    {
        try
        {
            var message = "Ocurrió un error. Revise el registro de Log"
                + Environment.NewLine + Environment.NewLine + ex.Message.ToString();

            MessageBox.Show(message, _title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch { }
    }

    public void ShowInformation(string message)
    {
        try
        {
            MessageBox.Show(message, _title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch { }
    }

    public MessageBoxResult ShowQuestion(string message)
        => MessageBox.Show(message, _title, MessageBoxButton.YesNo, MessageBoxImage.Question);
}
