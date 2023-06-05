using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace FluentMAUI.Samples.UI.Controls.SegmentedGroup;

public partial class SegmentedGroupWithEventVM : ObservableObject
{
    [ObservableProperty] IList<string> _segmentStringSource = new List<string>();

    public SegmentedGroupWithEventVM()
    {
    }

    [RelayCommand]
    public async Task OnViewAppearingAsync(CancellationToken cancellationToken)
    {
        this.SegmentStringSource.Clear();

        this.SegmentStringSource.Add("Option 1");
        this.SegmentStringSource.Add("Option 2");
        this.SegmentStringSource.Add("Option 3");
        this.SegmentStringSource.Add("Option 4");
    }
}