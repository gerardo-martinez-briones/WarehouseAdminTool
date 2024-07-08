using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Contracts.Wpf;
using Core.Features.Users.Queries.GetLogin;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Windows;
using Wpf.Services;
using Wpf.Views;

namespace Wpf.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<LoginViewModel> _logger;
    private readonly IMediator _mediator;
    private readonly ILoginModel _login;
    private readonly Helper _helper;

    public LoginViewModel(
        IConfiguration configuration,
        ILogger<LoginViewModel> logger,
        IMediator mediator,
        ILoginModel login,
        Helper helper)
    {
        _configuration = configuration;
        _logger = logger;
        _mediator = mediator;
        _login = login;
        _helper = helper;
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Password))]
    private string _username = string.Empty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Username))]
    private string _password = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private bool _canLogin = false;

    [ObservableProperty]
    private bool _showError = false;

    partial void OnUsernameChanging(string value)
        => CanLogin = (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(Password));

    partial void OnPasswordChanging(string value)
        => CanLogin = (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(value));

    [RelayCommand(CanExecute = nameof(CanLogin))]
    private async Task Login()
    {
        try
        {
            var getLoginQuery = new GetLoginQuery();

            getLoginQuery.Username = Username;
            getLoginQuery.Password = Encrypt.GetSHA256(Password);

            var getLoginresponse = await _mediator.Send(getLoginQuery);

            if (getLoginresponse != null)
            {
                _login.IdUser = getLoginresponse.IdUser;
                _login.IdProfile = getLoginresponse.IdProfile;
                _login.FullName = $"{getLoginresponse.FirstName} {getLoginresponse.LastName}";
                _login.Email = getLoginresponse.Email;
                _login.Username = getLoginresponse.UserName;

                var homeView = App.WpfHost.Services.GetRequiredService<HomeView>();

                homeView.Show();

                App.Current.MainWindow.Close();
            }
            else
            {
                ShowError = true;
                Username = string.Empty;
                Password = string.Empty;
            }
        }
        catch (Exception ex)
        {
            _helper.ShowError(ex);
            _helper.SetLogError(ex);
        }
    }

    [RelayCommand]
    private void CloseWindow()
    {
        try
        {
            if (_helper.ShowQuestion("Por favor confirme. ¿Esta seguro de Cerrar la Aplicacion?") == MessageBoxResult.Yes)
                App.Current.Shutdown();
        }
        catch (Exception ex)
        {
            _helper.ShowError(ex);
            _helper.SetLogError(ex);
        }
    }
}