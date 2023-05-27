using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using CommunityToolkit.Maui.Converters;

namespace FluentMAUI.Samples.UI.Converter;

public class ToggledEventArgsConverter : BaseConverterOneWay<FluentMAUI.UI.EventArgs.ToggledEventArgs, object>
{
    /// <inheritdoc/>
    public override object? DefaultConvertReturnValue { get; set; } = null;

    [return: NotNullIfNotNull(nameof(value))]
    public override object? ConvertFrom(FluentMAUI.UI.EventArgs.ToggledEventArgs? value, CultureInfo? culture = null) => value switch
    {
        null => null,
        _ => value.IsChecked
    };
}