using FluentMAUI.UI.EventArgs;

namespace FluentMAUI.UI.Interfaces;

public interface IToggleButton
{
    event EventHandler<CheckedEventArgs> Checked;
    
    /// <summary>
    /// Toggles the state of the button.
    /// </summary>
    void Toggle();
}