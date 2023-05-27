using CommunityToolkit.Maui;
using FluentMAUI.UI;
using FluentMAUI.UI.Controls;

namespace FluentMAUI.Samples.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });



        builder.UseFluentUi(options =>
        {

        });



        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();
        
        builder.Services.AddSingleton<Controls.BasicInput>();
        builder.Services.AddSingleton<Controls.BasicInputVM>();
        
        builder.Services.AddSingleton<Controls.ToggleButton.ToggleButtonWithEvent>();
        builder.Services.AddSingleton<Controls.ToggleButton.ToggleButtonWithEventVM>();
        builder.Services.AddSingleton<Controls.ToggleButton.ToggleButtonWithCommand>();
        builder.Services.AddSingleton<Controls.ToggleButton.ToggleButtonWithCommandVM>();
        
        return builder.Build();
    }
}

