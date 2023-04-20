using FluentMAUI.Configuration;

namespace FluentMAUI.Samples.Configuration;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.UseFluentConfiguration();

        // you can use it direct on maui builder like:
        // => builder.UseFluentConfiguration();
        // or on the .NET ConfigurationManager
        // => builder.Configuration.UseFluentConfiguration();


        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

        return builder.Build();
    }
}