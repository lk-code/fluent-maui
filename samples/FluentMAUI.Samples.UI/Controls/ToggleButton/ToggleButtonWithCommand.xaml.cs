namespace FluentMAUI.Samples.UI.Controls.ToggleButton;

public partial class ToggleButtonWithCommand : ContentPage
{
    private readonly ToggleButtonWithCommandVM _viewModel;
    
    public ToggleButtonWithCommand(ToggleButtonWithCommandVM viewModel)
    {
        InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }
}