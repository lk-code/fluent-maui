using FluentMAUI.UI.Controls;

namespace FluentMAUI.UI;

/// <summary>
/// FluentMAUI AppBuilderExtensions
/// </summary>
public static class AppBuilderExtensions
{
    /// <summary>
    /// initializes the FluentMAUI UI Library
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static MauiAppBuilder UseFluentUi(this MauiAppBuilder builder, Action<Options>? options = default)
    {
        builder.ConfigureMauiHandlers((handlers) =>
        {
#if ANDROID
                handlers.AddHandler(typeof(SegmentedGroup), typeof(FluentMAUI.UI.Droid.SegmentedGroupRenderer));
#elif IOS
                handlers.AddHandler(typeof(SegmentedGroup), typeof(FluentMAUI.UI.Ios.SegmentedGroupRenderer));
#elif MACCATALYST
            handlers.AddHandler(typeof(SegmentedGroup), typeof(FluentMAUI.UI.MacCatalyst.SegmentedGroupRenderer));
#elif WINDOWS
                handlers.AddHandler(typeof(SegmentedGroup), typeof(FluentMAUI.UI.Windows.SegmentedGroupRenderer));
#elif TIZEN
                handlers.AddHandler(typeof(SegmentedGroup), typeof(FluentMAUI.UI.Tizen.SegmentedGroupRenderer));
#endif
        });

        return builder;
    }
}