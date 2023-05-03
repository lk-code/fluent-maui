using FluentMAUI.UI.EventArgs;
using FluentMAUI.UI.Interfaces;

namespace FluentMAUI.UI.Controls;

public class ToggleButton : Button, IToggleButton
{
    private Color _primaryBackgroundColor = null;
    private Brush _primaryBackground = null;

    private bool _isChecked = false;
    public bool IsChecked
    {
        get { return this._isChecked; }
        set
        {
            this.OnPropertyChanging();

            this._isChecked = value;

            this.OnPropertyChanged();
        }
    }

    public event EventHandler<CheckedEventArgs> Checked = (e, a) => { };

    public static readonly BindableProperty SelectedBackgroundColorProperty = BindableProperty.Create(
        "SelectedBackgroundColor",
        typeof(Color),
        typeof(ToggleButton),
        null);

    public Color SelectedBackgroundColor
    {
        get => (Color)GetValue(SelectedBackgroundColorProperty);
        set => SetValue(SelectedBackgroundColorProperty, value);
    }

    public static readonly BindableProperty SelectedBackgroundProperty = BindableProperty.Create(
        "SelectedBackground",
        typeof(Brush),
        typeof(ToggleButton),
        null);

    public Brush SelectedBackground
    {
        get => (Brush)GetValue(SelectedBackgroundProperty);
        set => SetValue(SelectedBackgroundProperty, value);
    }

    public ToggleButton() : base()
    {
        this.Clicked += ToggleButton_Clicked;
    }

    ~ToggleButton()
    {
        this.Clicked -= ToggleButton_Clicked;
    }

    private void ToggleButton_Clicked(object sender, System.EventArgs e)
    {
        this.IsChecked = !this.IsChecked;
        
        this.Checked?.Invoke(this, new CheckedEventArgs(this.IsChecked));

        if (this.IsChecked)
        {
            this._primaryBackgroundColor = this.BackgroundColor;
            this._primaryBackground = this.Background;

            this.BackgroundColor = this.SelectedBackgroundColor;
            this.Background = this.SelectedBackground;
        }
        else
        {
            this.BackgroundColor = this._primaryBackgroundColor;
            this.Background = this._primaryBackground;
        }
    }
}