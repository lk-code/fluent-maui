namespace FluentMAUI.Samples.UI.Controls.ToggleButton;

public partial class ToggleButtonWithBinding : ContentPage
{
    private readonly ToggleButtonWithBindingVM _viewModel;

    public ToggleButtonWithBinding(ToggleButtonWithBindingVM viewModel)
    {
        InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }
}