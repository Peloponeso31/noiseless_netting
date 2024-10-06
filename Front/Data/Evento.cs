using CommunityToolkit.Mvvm.ComponentModel;

namespace Front.Data;

public partial class Evento: ObservableObject
{
    public Evento(string eventname, string plottype, string plotimage)
    {
        _eventname = eventname;
        _plottype = plottype;
        _plotimage = plotimage;
    }

    public Evento() { }

    [ObservableProperty] private string _eventname;
    [ObservableProperty] private string _plottype;
    [ObservableProperty] private string _plotimage;
    
}