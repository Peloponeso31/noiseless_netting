using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using Front.Core.demo;
using Front.Core.Services.BackendService;
using Front.Core.Services.MiniSeedService;
using Front.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Front.Features.EventDetails;

public partial class EventDetailsViewModel :ObservableObject
{
   private IMiniSeedService _miniSeedService = App.Current.Services.GetService<IMiniSeedService>()!;
   private IBackendService _backendService = App.Current.Services.GetService<IBackendService>()!;
   
   [ObservableProperty] private ObservableCollection<Evento> _eventos = Core.demo.ListaEventos.Eventos;
   [ObservableProperty] private string _nombreEvento;
   [ObservableProperty] private Evento _eventoPlot;

   public EventDetailsViewModel()
   {
      InitAsync();
   }

   private async void InitAsync()
   {
      NombreEvento = Path.GetFileNameWithoutExtension(_miniSeedService.GetCurrentFile());
      var image = await _backendService.Call($"--filename {_miniSeedService.GetCurrentFile()}", "backend.py");
      EventoPlot = new()
      {
         Eventname = "Plot",
         Plotimage = image
      };
   }
}