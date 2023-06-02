using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace FluentMAUI.Samples.UI.Controls.ToggleButton;

public partial class ToggleButtonWithBindingVM : ObservableObject
{
    [ObservableProperty] bool _isChecked = false;

    public ToggleButtonWithBindingVM()
    {
    }

    [RelayCommand]
    public async Task OnViewAppearingAsync(CancellationToken cancellationToken)
    {
    }

    [RelayCommand]
    public async Task OnToggleAsync(CancellationToken cancellationToken)
    {
        this.IsChecked = !this.IsChecked;
    }
}