using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;

namespace FluentMAUI.Samples.UI;

public partial class MainViewModel : ObservableObject
{
    public MainViewModel(IConfiguration configuration)
    {
    }

    [RelayCommand]
    public async Task OnViewAppearingAsync(CancellationToken cancellationToken)
    {
    }
}