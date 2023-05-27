using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentMAUI.Samples.UI.Models;

namespace FluentMAUI.Samples.UI.Controls;

public partial class LayoutVM : ObservableObject
{
    [ObservableProperty] ObservableCollection<PageItem> pages = new();

    public LayoutVM()
    {

    }

    [RelayCommand]
    public async Task OnViewAppearingAsync(CancellationToken cancellationToken)
    {
        this.Pages.Clear();

        this.Pages.Add(new("Widgets", "controls/widgets"));
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
