using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Front.Core.Services.Navigation;
using Front.Features.EventDetails;
using Front.Features.ListaEventos;
using Microsoft.Extensions.DependencyInjection;
using Wpf.Ui.Controls;

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
        _navigationService.Navigate(typeof(EventDetailsPage));
    }
}