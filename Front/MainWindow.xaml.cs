using System.Windows;
using Front.Core.Services.Navigation;
using Front.Features.EventDetails;
using Front.Features.ListaEventos;
using Microsoft.Extensions.DependencyInjection;

namespace Front;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    private INavigationService _navigationService = App.Current.Services.GetService<INavigationService>()!; 

    public MainWindow()
    {
        InitializeComponent();
        _navigationService.SetNavigationControl(NavigationView);
    }

    private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        _navigationService.Navigate(typeof(ListaEventosPage));
    }
}