namespace FluentMAUI.Samples.UI.Controls.Widget;

public partial class WidgetsInsideGrid : ContentPage
{
    private readonly WidgetsInsideGridVM _viewModel;

    public WidgetsInsideGrid(WidgetsInsideGridVM viewModel)
    {
        InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }
}