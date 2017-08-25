using System;

namespace WTManager.Controls.WtStyle.WtConfigurator
{
    public interface IVisualProviderObject
    {
    }

    public interface IDependentStateProvider
    {
        event Action<string, bool> StateChanged;
        bool CurrentState { get; }
    }
}