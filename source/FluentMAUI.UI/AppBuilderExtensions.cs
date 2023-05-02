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
        return builder;
    }
}