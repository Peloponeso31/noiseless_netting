using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Front.Core.demo;
using Front.Data;

namespace Front.Features.EventDetails;

public partial class EventDetailsViewModel :ObservableObject
{
   [ObservableProperty] private ObservableCollection<Evento> _eventos = Core.demo.ListaEventos.Eventos;

}