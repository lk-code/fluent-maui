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

        this.Pages.Add(new("Toggle Button with Event", typeof(ToggleButton.ToggleButtonWithEvent)));
    }
}
