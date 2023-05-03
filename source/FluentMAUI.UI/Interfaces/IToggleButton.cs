using FluentMAUI.UI.EventArgs;

namespace FluentMAUI.UI.Interfaces;

public interface IToggleButton
{
    event EventHandler<CheckedEventArgs> Checked;
}