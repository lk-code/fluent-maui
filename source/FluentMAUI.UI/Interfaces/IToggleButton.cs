using FluentMAUI.UI.EventArgs;
using ToggledEventArgs = FluentMAUI.UI.EventArgs.ToggledEventArgs;

namespace FluentMAUI.UI.Interfaces;

public interface IToggleButton
{
    event EventHandler<ToggledEventArgs> Toggled;
    
    /// <summary>
    /// Toggles the state of the button.
    /// </summary>
    void Toggle();
}