using System.Reflection;
using CommunityToolkit.Maui;
using FluentMAUI.Configuration;

namespace FluentMAUI.Samples.Configuration;

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



        builder.UseFluentConfiguration(Assembly.GetExecutingAssembly());

        // you can use it direct on maui builder like:
        // => builder.UseFluentConfiguration(Assembly.GetExecutingAssembly());
        // or on the .NET ConfigurationManager
        // => builder.Configuration.UseFluentConfiguration(Assembly.GetExecutingAssembly());
        //
        // NOTE: Assembly is optional for ios, macos and winui
        // but required for android!



        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

        return builder.Build();
    }
}