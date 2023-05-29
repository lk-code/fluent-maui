using CommunityToolkit.Maui;
using FluentMAUI.UI;
using FluentMAUI.UI.Controls;
using Microsoft.Maui.LifecycleEvents;

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

        builder.ConfigureLifecycleEvents(events =>
        {
#if WINDOWS10_0_17763_0_OR_GREATER

            events.AddWindows(wndLifeCycleBuilder =>
            {
                wndLifeCycleBuilder.OnWindowCreated(window =>
                {
                    // *** For Mica or Acrylic support ** //
                    window.TryMicaOrAcrylic();
                });
            });
#endif
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

        builder.Services.AddSingleton<Controls.Layout>();
        builder.Services.AddSingleton<Controls.LayoutVM>();

        builder.Services.AddSingleton<Controls.Widget.WidgetsInsideGrid>();
        builder.Services.AddSingleton<Controls.Widget.WidgetsInsideGridVM>();

        return builder.Build();
    }
}

