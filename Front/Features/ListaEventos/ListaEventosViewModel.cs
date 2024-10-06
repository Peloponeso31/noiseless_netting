using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Front.Features.ListaEventos;

public partial class ListaEventosViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<string> _miniSeeds;
    [ObservableProperty] private ObservableCollection<string> _datosFiltrados; // Lista para los datos filtrados

    // Colección para almacenar las opciones del ComboBox
    public ObservableCollection<string> OpcionesCombo { get; set; }

    private string _opcionSeleccionada;
    public string OpcionSeleccionada
    {
        get => _opcionSeleccionada;
        set
        {
            if (SetProperty(ref _opcionSeleccionada, value))
            {
                FiltrarDatos(); // Llamar al método de filtrado cuando cambia la opción seleccionada
            }
        }
    }

    public ListaEventosViewModel()
    {
        var myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var files = Directory.GetFiles(Path.Combine(myDocumentsPath, "MiniSeeds"));

        MiniSeeds = new ObservableCollection<string>(files);
        DatosFiltrados = new ObservableCollection<string>(MiniSeeds); // Inicializa con todos los archivos

        // Inicializar la lista de opciones del ComboBox
        OpcionesCombo = new ObservableCollection<string>
        {
            "Luna",
            "Marte"
        };
    }

    // Método para filtrar los archivos de acuerdo con la opción seleccionada
    private void FiltrarDatos()
    {
        var datosFiltrados = MiniSeeds.Where(x =>
        {
            // Filtrar por el nombre del archivo según la opción seleccionada
            if (OpcionSeleccionada == "Luna")
            {
                return x.Contains("s12", StringComparison.OrdinalIgnoreCase);
            }
            else if (OpcionSeleccionada == "Marte")
            {
                return x.Contains("ELYSE", StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                return true; // Si no hay opción seleccionada o no coincide con "Luna" o "Marte", muestra completa
            }
        });

        DatosFiltrados = new ObservableCollection<string>(datosFiltrados); // Actualiza la lista filtrada
    }
}
