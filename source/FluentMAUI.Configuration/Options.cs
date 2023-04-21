using System.Reflection;

namespace FluentMAUI.Configuration;

/// <summary>
/// Options for FluentMAUI initialization
/// </summary>
public class Options
{
    /// <summary>
    /// Specify the assembly from which the appsettings are to be loaded.
    /// </summary>
    public Assembly? LoadAppsettingsFrom { get; set; } = null;
}