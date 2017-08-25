using System;

namespace WTManager.Controls.WtStyle.WtConfigurator
{
    public interface IDependentStateProvider
    {
        event Action<string, bool> StateChanged;
        bool CurrentState { get; }
    }
}