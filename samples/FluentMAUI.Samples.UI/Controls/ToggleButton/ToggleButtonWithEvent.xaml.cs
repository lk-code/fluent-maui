using FluentMAUI.UI.EventArgs;
using ToggledEventArgs = FluentMAUI.UI.EventArgs.ToggledEventArgs;

namespace FluentMAUI.Samples.UI.Controls.ToggleButton;

public partial class ToggleButtonWithEvent : ContentPage
{
    private readonly ToggleButtonWithEventVM _viewModel;

    public ToggleButtonWithEvent(ToggleButtonWithEventVM viewModel)
    {
        InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }

    private void ToggleButton_OnChecked(object? sender, ToggledEventArgs e)
    {
        if (e.IsChecked)
        {
            this.ToggleButtonLabel.Text = "checked";
        }
        else
        {
            this.ToggleButtonLabel.Text = "not checked";
        }
    }
}