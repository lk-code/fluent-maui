using FluentMAUI.UI.Interfaces;
using ToggledEventArgs = FluentMAUI.UI.EventArgs.ToggledEventArgs;

namespace FluentMAUI.UI.Controls;

public class ToggleButton : Button, IToggleButton
{
    private Color _primaryBackgroundColor = null;
    private Brush _primaryBackground = null;
    private Color _primaryTextColor = null;
    public event EventHandler<ToggledEventArgs> Toggled = (e, a) => { };

    public static readonly BindableProperty CheckedBackgroundColorProperty = BindableProperty.Create(
        "CheckedBackgroundColor",
        typeof(Color),
        typeof(ToggleButton),
        null);

    public Color CheckedBackgroundColor
    {
        get => (Color)GetValue(CheckedBackgroundColorProperty);
        set => SetValue(CheckedBackgroundColorProperty, value);
    }

    public static readonly BindableProperty CheckedBackgroundProperty = BindableProperty.Create(
        "CheckedBackground",
        typeof(Brush),
        typeof(ToggleButton),
        null);

    public Brush CheckedBackground
    {
        get => (Brush)GetValue(CheckedBackgroundProperty);
        set => SetValue(CheckedBackgroundProperty, value);
    }

    public static readonly BindableProperty CheckedTextColorProperty = BindableProperty.Create(
        "CheckedTextColor",
        typeof(Color),
        typeof(ToggleButton),
        null);

    public Color CheckedTextColor
    {
        get => (Color)GetValue(CheckedTextColorProperty);
        set => SetValue(CheckedTextColorProperty, value);
    }

    public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(
        "IsChecked",
        typeof(bool),
        typeof(ToggleButton),
        null,
        BindingMode.TwoWay,
        propertyChanged: OnIsCheckedPropertyChanged);

    public bool IsChecked
    {
        get => (bool)GetValue(IsCheckedProperty);
        set
        {
            this.OnPropertyChanging();

            SetValue(IsCheckedProperty, value);

            this.OnPropertyChanged();
        }
    }
    
    private static void OnIsCheckedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (ToggleButton)bindable;
        
        ToggledEventArgs eventArgs = control.CreateEventArgs();
        control.Toggled?.Invoke(control, eventArgs);

        control.ToggleColor();
    }

    public ToggleButton() : base()
    {
        this.Clicked += ToggleButton_Clicked;
        ApplyStandardButtonStyle();
    }

    ~ToggleButton()
    {
        this.Clicked -= ToggleButton_Clicked;
    }

    private void ToggleButton_Clicked(object sender, System.EventArgs e)
    {
        this.Toggle();
    }

    /// <inheritdoc />
    public void Toggle()
    {
        this.IsChecked = !this.IsChecked;
    }

    private void ToggleColor()
    {
        if (this.IsChecked)
        {
            this._primaryBackgroundColor = this.BackgroundColor;
            this._primaryBackground = this.Background;
            this._primaryTextColor = this.TextColor;

            this.BackgroundColor = this.CheckedBackgroundColor;
            this.Background = this.CheckedBackground;
            this.TextColor = this.CheckedTextColor;
        }
        else
        {
            this.BackgroundColor = this._primaryBackgroundColor;
            this.Background = this._primaryBackground;
            this.TextColor = this._primaryTextColor;
        }
    }

    private ToggledEventArgs CreateEventArgs()
    {
        ToggledEventArgs eventArgs = new ToggledEventArgs(this.IsChecked);

        return eventArgs;
    }

    private void ApplyStandardButtonStyle()
    {
        // copy style from Button
        Button btn = new Button();

        this.Background = btn.Background;
        this.CornerRadius = btn.CornerRadius;
        this.Margin = btn.Margin;
        this.Opacity = btn.Opacity;
        this.Padding = btn.Padding;
        this.Resources = btn.Resources;
        this.Rotation = btn.Rotation;
        this.Scale = btn.Scale;
        this.Shadow = btn.Shadow;
        this.Style = btn.Style;
        this.Visual = btn.Visual;
        this.BorderColor = btn.BorderColor;
        this.BorderWidth = btn.BorderWidth;
        this.CharacterSpacing = btn.CharacterSpacing;
        this.FlowDirection = btn.FlowDirection;
        this.FontAttributes = btn.FontAttributes;
        this.FontFamily = btn.FontFamily;
        this.FontSize = btn.FontSize;
        this.FontAutoScalingEnabled = this.FontAutoScalingEnabled;
        this.HeightRequest = btn.HeightRequest;
        this.WidthRequest = btn.WidthRequest;
        this.MaximumHeightRequest = btn.MaximumHeightRequest;
        this.MaximumWidthRequest = btn.MaximumWidthRequest;
        this.MinimumHeightRequest = btn.MinimumHeightRequest;
        this.MinimumWidthRequest = btn.MinimumWidthRequest;
        this.TextColor = btn.TextColor;
        this.TextTransform = btn.TextTransform;
    }
}