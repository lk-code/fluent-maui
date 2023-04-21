using System.Diagnostics;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace FluentMAUI.Configuration;

public static class ConfigurationLoader
{
    /// <summary>
    /// add fluent configuration to .NET IConfigurationBuilder
    /// </summary>
    /// <param name="configurationBuilder">the .NET IConfigurationBuilder</param>
    /// <param name="configureDelegate">Options for FluentMAUI initialization</param>
    /// <returns></returns>
    public static IConfigurationBuilder UseFluentConfiguration(this IConfigurationBuilder configurationBuilder, Action<Options>? configureDelegate = default)
    {
        Options options = new Options();
        configureDelegate?.Invoke(options);
        
        if(options.LoadAppsettingsFrom is null)
        {
            options.LoadAppsettingsFrom = Assembly.GetEntryAssembly();
        }

        // can still be zero on Android.
        if (options.LoadAppsettingsFrom is null)
        {
            throw new ArgumentNullException(nameof(options.LoadAppsettingsFrom), "LoadAppsettingsFrom Assembly is null");
        }

        string? assemblyName = options.LoadAppsettingsFrom.GetName().Name;
        if (assemblyName is null)
        {
            throw new ArgumentNullException(nameof(assemblyName), "Assembly Name is null");
        }

        string platform = DeviceInfo.Current.Platform.ToString().ToLowerInvariant();
        string environment = "Debug";
#if RELEASE
    environment = "Release";
#endif

        IEnumerable<string> appsettingFileNames = new List<string>
        {
            "appsettings.json",                                             // appsettings.json
            "appsettings." + platform + ".json",                            // appsettings.winui.json
            "appsettings." + environment + ".json",                         // appsettings.Debug.json
            "appsettings." + platform + "." + environment + ".json"         // appsettings.winui.Debug.json
        };

        foreach (string appsettingFileName in appsettingFileNames)
        {
            string appsettingsFullFileName = $"{assemblyName}.{appsettingFileName}";

#if DEBUG
            Debug.Write($"try to load appsettings from: {appsettingsFullFileName} ... ");
#endif

            using Stream? appsettingsStream = options.LoadAppsettingsFrom.GetManifestResourceStream(appsettingsFullFileName);

            if (appsettingsStream is not null)
            {
                configurationBuilder.AddJsonStream(appsettingsStream);

#if DEBUG
                Debug.WriteLine("FOUND");
#endif
            }
            else
            {
#if DEBUG
                Debug.WriteLine("NOT FOUND");
#endif
            }
        }

        return configurationBuilder;
    }


    /// <summary>
    /// add fluent configuration to maui instance
    /// </summary>
    /// <param name="builder">the net maui builder</param>
    /// <param name="configureDelegate">Options for FluentMAUI initialization</param>
    /// <returns></returns>
    public static MauiAppBuilder UseFluentConfiguration(this MauiAppBuilder builder, Action<Options>? configureDelegate = default)
    {
        builder.Configuration.UseFluentConfiguration(configureDelegate);

        return builder;
    }
}