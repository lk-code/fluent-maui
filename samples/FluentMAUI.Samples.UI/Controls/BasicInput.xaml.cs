namespace FluentMAUI.Samples.UI.Controls;

public partial class BasicInput : ContentPage
{
    private readonly BasicInputVM _viewModel;
    
    public BasicInput(BasicInputVM viewModel)
    {
        InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }
}