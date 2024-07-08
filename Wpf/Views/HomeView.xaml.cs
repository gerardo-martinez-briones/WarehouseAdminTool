using System.Windows;
using Wpf.ViewModels;

namespace Wpf.Views;

public partial class HomeView : Window
{
    public HomeView(HomeViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }
}