using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace FluentMAUI.Samples.UI.Controls.ToggleButton;

public partial class ToggleButtonWithCommandVM : ObservableObject
{
    [ObservableProperty] string _message = string.Empty;

    public ToggleButtonWithCommandVM()
    {
    }

    [RelayCommand]
    public async Task OnViewAppearingAsync(CancellationToken cancellationToken)
    {
    }

    [RelayCommand]
    public async Task OnToggleAsync(bool isChecked,
        CancellationToken cancellationToken)
    {
        if (isChecked)
        {
            this.Message = "checked";
        }
        else
        {
            this.Message = "not checked";
        }
    }
}