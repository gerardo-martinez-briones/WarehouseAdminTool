using CommunityToolkit.Mvvm.ComponentModel;
using Core.Contracts.Wpf;

namespace Wpf.Models;

public partial class ReviewedUserModel : ObservableObject, IReviewedUserModel
{
    [ObservableProperty]
    private int idUser;

    [ObservableProperty]
    private string fullName;
}