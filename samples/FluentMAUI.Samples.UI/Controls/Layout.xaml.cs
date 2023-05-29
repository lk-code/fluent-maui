namespace FluentMAUI.Samples.UI.Controls;

public partial class Layout : ContentPage
{
    private readonly LayoutVM _viewModel;

    public Layout(LayoutVM viewModel)
    {
        InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }
}