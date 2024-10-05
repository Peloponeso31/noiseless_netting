using Wpf.Ui.Abstractions.Controls;
using Wpf.Ui.Controls;

namespace Front.Core.Services.Navigation;

public interface INavigationService
{
    void Navigate(Type pageType);

    void SetNavigationControl(INavigationView navigation);
}