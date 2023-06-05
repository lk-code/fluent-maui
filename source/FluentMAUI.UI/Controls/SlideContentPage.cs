using System.ComponentModel;

namespace FluentMAUI.UI.Controls;

[DesignTimeVisible(true)]
[ContentProperty(nameof(TabContent))]
public class SlideContentPage : Button
{
    public static readonly BindableProperty TabContentProperty = BindableProperty.Create(
        "TabContent",
        typeof(View),
        typeof(SlideContentPage),
        null);

    public View TabContent
    {
        get => (View)GetValue(TabContentProperty);
        set => SetValue(TabContentProperty, value);
    }
}