using System.Collections.ObjectModel;
using Front.Data;

namespace Front.Core.demo;

public static class ListaEventos
{
     private static Evento _evento1 = new ("nameExample","nose JAJAJA","Assets\\imagenotfound.png");
    private static Evento _evento2 = new ("nameExample2","nose2 JAJAJA","Assets\\imagenotfound.png");
    private static Evento _evento3 = new ("nameExample3","nose3 JAJAJA","Assets\\imagenotfound.png");
    public static ObservableCollection<Evento> Eventos = [_evento1, _evento2, _evento3]; 
}