namespace FluentMAUI.UI.EventArgs;

public class CheckedEventArgs : System.EventArgs
{
    public bool IsChecked { get; set; } = false;

    public CheckedEventArgs(bool isChecked)
    {
        IsChecked = isChecked;
    }
}