using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;
using System;

namespace FluentMAUI.Samples.Configuration;

public partial class MainViewModel : ObservableObject
{
    private readonly IConfiguration _configuration;
    [ObservableProperty] string titleMessage = string.Empty;

    public MainViewModel(IConfiguration configuration)
	{
        this._configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    [RelayCommand]
    public async Task OnViewAppearingAsync(CancellationToken cancellationToken)
    {
        string title = this._configuration.GetSection("Title").Value;
        this.TitleMessage = title;
    }
}