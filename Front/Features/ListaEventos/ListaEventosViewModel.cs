using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Front.Features.ListaEventos;

public partial class ListaEventosViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<string> _miniSeeds;

    public ListaEventosViewModel()
    {
        var myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var files = Directory.GetFiles(Path.Combine(myDocumentsPath, "MiniSeeds"));

        MiniSeeds = new ObservableCollection<string>(files);
    }
}