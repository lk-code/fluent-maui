namespace FluentMAUI.Samples.UI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		
		Routing.RegisterRoute("controls/togglebutton-with-event", typeof(Controls.ToggleButton.ToggleButtonWithEvent));
	}
}

