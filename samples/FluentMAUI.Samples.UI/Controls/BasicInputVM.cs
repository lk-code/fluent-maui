using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentMAUI.Samples.UI.Models;
using System.Collections.ObjectModel;

namespace FluentMAUI.Samples.UI.Controls;

public partial class BasicInputVM : ObservableObject
{
    [ObservableProperty] ObservableCollection<PageItem> pages = new();

    public BasicInputVM()
    {

    }

    [RelayCommand]
    public async Task OnViewAppearingAsync(CancellationToken cancellationToken)
    {
        this.Pages.Clear();

        this.Pages.Add(new("Toggle Button with Event", "controls/togglebutton-with-event"));
        this.Pages.Add(new("Toggle Button with Command", "controls/togglebutton-with-command"));
    }

    [RelayCommand]
    public async Task OnNavigationSelectedAsync(List<object> selected, CancellationToken cancellationToken)
    {
        PageItem? page = (PageItem?)selected.FirstOrDefault();
        if (page is null)
        {
            return;
        }
        
        await Shell.Current.GoToAsync(page.Route, true);
    }
}
