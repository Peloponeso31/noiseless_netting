using System.Windows.Controls;
using System.Windows.Input;

namespace Front.Features.ListaEventos;

public partial class ListaEventosPage : Page
{
    public ListaEventosPage()
    {
        InitializeComponent();
    }

    private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (DataContext is ListaEventosViewModel vm)
        {
            vm.MiniSeedClickCommand.Execute(null);
        }
    }
}