using System.Windows;
using System.Windows.Input;
using Wpf.ViewModels;

namespace Wpf.Views;

public partial class LoginView : Window
{
    public LoginView(LoginViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
        MouseDown += OnMouseDown;
    }

    private void OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
            this.DragMove();
    }
}