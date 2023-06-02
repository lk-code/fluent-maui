
using FluentMAUI.Core.Extensions;

namespace FluentMAUI.UI.Controls;

public class WidgetView : Border
{
    public static readonly BindableProperty BackgroundStyleTypeProperty = BindableProperty.Create(
        "BackgroundStyleType",
        typeof(BackgroundStyleTypes),
        typeof(WidgetView),
        null);

    public BackgroundStyleTypes BackgroundStyleType
    {
        get => (BackgroundStyleTypes)GetValue(BackgroundStyleTypeProperty);
        set
        {
            SetValue(BackgroundStyleTypeProperty, value);

            // update colors
            this.UpdateBackgroundColors();
        }
    }

    public WidgetView()
    {
        this.Loaded += WidgetView_OnLoaded;
    }

    ~WidgetView()
    {
        this.Loaded -= WidgetView_OnLoaded;
    }

    private void WidgetView_OnLoaded(object? sender, System.EventArgs e)
    {
        this.UpdateBackgroundColors();
    }

    protected void UpdateBackgroundColors()
    {
        if (this.BackgroundColor is null
            || this.BackgroundColor.Equals(Color.FromRgb(0, 0, 0)))
        {
            return;
        }

        switch (this.BackgroundStyleType)
        {
            case BackgroundStyleTypes.Flat:
            {
                // do nothing => it is already flat color
            }
                break;
            case BackgroundStyleTypes.Gradient:
            {
                // get BackgroundColor, create gradient and set it to Background (brush)
                Color startBackgroundColor = this.BackgroundColor;
                Color endBackgroundColor = this.BackgroundColor.Darken(15);

                Brush background = new LinearGradientBrush()
                {
                    StartPoint = new Point(0, 0),
                    EndPoint = new Point(0, 1),
                    GradientStops = new GradientStopCollection()
                    {
                        new GradientStop(startBackgroundColor, 0),
                        new GradientStop(endBackgroundColor, 1)
                    }
                };
                this.Background = background;
            }
                break;
        }
    }
}