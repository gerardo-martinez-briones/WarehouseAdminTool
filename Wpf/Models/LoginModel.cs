using CommunityToolkit.Mvvm.ComponentModel;
using Core.Contracts.Wpf;

namespace Wpf.Models;

public partial class LoginModel : ObservableObject, ILoginModel
{
    [ObservableProperty]
    private int idUser;

    [ObservableProperty]
    private int idProfile;

    [ObservableProperty]
    private string fullName;

    [ObservableProperty]
    private string email;

    [ObservableProperty]
    private string username;
}