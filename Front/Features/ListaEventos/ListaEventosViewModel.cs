using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Front.Core.Services.MiniSeedService;
using Front.Core.Services.Navigation;
using Front.Features.EventDetails;
using Microsoft.Extensions.DependencyInjection;

namespace Front.Features.ListaEventos;

public partial class ListaEventosViewModel : ObservableObject
{
    private IMiniSeedService _miniSeedService = App.Current.Services.GetService<IMiniSeedService>()!;
    private INavigationService _navigationService = App.Current.Services.GetService<INavigationService>()!;
    
    [ObservableProperty] private ObservableCollection<string> _miniSeeds;
    [ObservableProperty] private string _miniSeedSelected = string.Empty;

    public ListaEventosViewModel()
    {
        var myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var files = Directory.GetFiles(Path.Combine(myDocumentsPath, "MiniSeeds"));

        MiniSeeds = new ObservableCollection<string>(files);
    }

    [RelayCommand]
    private void OnMiniSeedClick()
    {
        _miniSeedService.SetCurrentFile(MiniSeedSelected);
        _navigationService.Navigate(typeof(EventDetailsPage));
    }
}