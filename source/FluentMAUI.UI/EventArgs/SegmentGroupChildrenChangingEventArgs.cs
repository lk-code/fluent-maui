using FluentMAUI.UI.Controls;

namespace FluentMAUI.UI.EventArgs;

public class SegmentGroupChildrenChangingEventArgs : System.EventArgs
{
    public IList<SegmentedGroupItem> OldValues { get; }
    public IList<SegmentedGroupItem> NewValues { get; }

    public SegmentGroupChildrenChangingEventArgs(IList<SegmentedGroupItem> oldValues,
        IList<SegmentedGroupItem> newValues)
    {
        OldValues = oldValues;
        NewValues = newValues;
    }
}