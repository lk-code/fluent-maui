using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using CommunityToolkit.Maui.Converters;

namespace FluentMAUI.Samples.UI.Converter;

public class SelectionChangedEventArgsConverter : BaseConverterOneWay<SelectionChangedEventArgs, object>
{
    /// <inheritdoc/>
    public override object? DefaultConvertReturnValue { get; set; } = null;

    [return: NotNullIfNotNull(nameof(value))]
    public override object? ConvertFrom(SelectionChangedEventArgs? value, CultureInfo? culture = null) => value switch
    {
        null => null,
        _ => value.CurrentSelection
    };
}