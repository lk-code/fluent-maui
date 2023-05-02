using CommunityToolkit.Maui;
using FluentMAUI.UI;

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
		
		
		
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

