using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace FluentMAUI.Samples.UI.Controls.SlideContentView;

public partial class SlideContentViewDefaultVM : ObservableObject
{
    public SlideContentViewDefaultVM()
    {
        
    }

    [RelayCommand]
    public async Task OnViewAppearingAsync(CancellationToken cancellationToken)
    {
    }
}