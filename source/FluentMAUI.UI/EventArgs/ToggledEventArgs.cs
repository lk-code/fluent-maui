namespace FluentMAUI.UI.EventArgs;

public class ToggledEventArgs : System.EventArgs
{
    public bool IsChecked { get; set; } = false;

    public ToggledEventArgs(bool isChecked)
    {
        IsChecked = isChecked;
    }
}