namespace FluentMAUI.Samples.UI.Controls.SegmentedGroup;

public partial class SegmentedGroupWithEvent : ContentPage
{
    private readonly SegmentedGroupWithEventVM _viewModel;

    public SegmentedGroupWithEvent(SegmentedGroupWithEventVM viewModel)
    {
        InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }
}