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
    
    // Colección para almacenar las opciones del ComboBox
    public ObservableCollection<string> OpcionesCombo { get; set; }
    
    
    private string _opcionSeleccionada;
    public string OpcionSeleccionada
    {
        get => _opcionSeleccionada;
        set => SetProperty(ref _opcionSeleccionada, value);
    }

    public ListaEventosViewModel()
    {
        var myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var files = Directory.GetFiles(Path.Combine(myDocumentsPath, "MiniSeeds"));

        MiniSeeds = new ObservableCollection<string>(files);
        
        // Inicializar la lista de opciones del ComboBox
        OpcionesCombo = new ObservableCollection<string>
        {
            "Luna",
            "Marte"
        };
        
    }

    [RelayCommand]
    private void OnMiniSeedClick()
    {
        _miniSeedService.SetCurrentFile(MiniSeedSelected);
        _navigationService.Navigate(typeof(EventDetailsPage));
    }
}