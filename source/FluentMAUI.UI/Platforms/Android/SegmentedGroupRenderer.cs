using FluentMAUI.UI.Controls;
using Microsoft.Maui.Controls.Compatibility;

[assembly: ExportRenderer(typeof(SegmentedGroup), typeof(FluentMAUI.UI.Droid.SegmentedGroupRenderer))]

namespace FluentMAUI.UI.Droid;

public class SegmentedGroupRenderer : ViewRenderer<SegmentedGroup, RadioGroup>
{
    
}