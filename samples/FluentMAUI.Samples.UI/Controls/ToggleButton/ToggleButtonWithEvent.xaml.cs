namespace FluentMAUI.Samples.UI.Controls.ToggleButton;

public partial class ToggleButtonWithEvent : ContentPage
{
    private readonly ToggleButtonWithEventVM _viewModel;

    public ToggleButtonWithEvent(ToggleButtonWithEventVM viewModel)
    {
        InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }

    private void ToggleButton_OnChecked(object? sender, bool e)
    {
        if (this.ToggleButton.IsChecked)
        {
            this.ToggleButtonLabel.Text = "is checked";
        }
        else
        {
            this.ToggleButtonLabel.Text = "isn't checked";
        }
    }
}