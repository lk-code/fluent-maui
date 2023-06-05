namespace FluentMAUI.Samples.UI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		
		Routing.RegisterRoute("controls/segmentedgroup-with-event", typeof(Controls.SegmentedGroup.SegmentedGroupWithEvent));
		
		Routing.RegisterRoute("controls/togglebutton-with-event", typeof(Controls.ToggleButton.ToggleButtonWithEvent));
		Routing.RegisterRoute("controls/togglebutton-with-command", typeof(Controls.ToggleButton.ToggleButtonWithCommand));
		Routing.RegisterRoute("controls/togglebutton-with-binding", typeof(Controls.ToggleButton.ToggleButtonWithBinding));
		
		Routing.RegisterRoute("controls/widgets", typeof(Controls.Widget.WidgetsInsideGrid));
	}
}

