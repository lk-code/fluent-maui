using System.Diagnostics;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace FluentMAUI.Configuration;

public static class ConfigurationLoader
{
    /// <summary>
    /// add fluent configuration to .NET IConfigurationBuilder
    /// </summary>
    /// <param name="configurationManager">the .NET IConfigurationBuilder</param>
    /// <returns></returns>
    public static IConfigurationBuilder UseFluentConfiguration(this IConfigurationBuilder configurationManager)
    {
        IConfigurationBuilder configBuilder = new ConfigurationBuilder();
        Assembly assembly = Assembly.GetExecutingAssembly();
        string? assemblyName = assembly.GetName().Name;

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
            "appsettings.json",                                 // appsettings.json
            $"appsettings.{platform}.json",                     // appsettings.winui.json
            $"appsettings.{environment}.json",                  // appsettings.Debug.json
            $"appsettings.{platform}.{environment}.json"        // appsettings.winui.Debug.json
        };

        foreach (string appsettingFileName in appsettingFileNames)
        {
            string appsettingsFullFileName = $"{assemblyName}.{appsettingFileName}";
            Debug.Write($"try to load appsettings from: {appsettingsFullFileName} ... ");
            
            using Stream? appsettingsStream = assembly.GetManifestResourceStream(appsettingsFullFileName);
            if (appsettingsStream is not null)
            {
                configBuilder = configBuilder.AddJsonStream(appsettingsStream);
                Debug.WriteLine("FOUND");
            }
            else
            {
                Debug.WriteLine("NOT FOUND");
            }
        }

        // build config
        IConfigurationRoot config = configBuilder.Build();
        configurationManager = configurationManager.AddConfiguration(config);

        return configurationManager;
    }

    /// <summary>
    /// add fluent configuration to maui instance
    /// </summary>
    /// <param name="builder">the net maui builder</param>
    /// <returns></returns>
    public static MauiAppBuilder UseFluentConfiguration(this MauiAppBuilder builder)
    {
        builder.Configuration.UseFluentConfiguration();

        return builder;
    }
}