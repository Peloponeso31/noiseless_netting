using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Front.Features.ListaEventos;

public partial class ListaEventosViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<string> _miniSeeds;
    
    
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

    
    
}