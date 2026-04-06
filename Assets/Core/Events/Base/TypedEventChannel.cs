using System;

namespace Core.Events.Base
{
    public abstract class TypedEventChannel<T> : EventChannelBase
    {
        public event Action<T> OnEventRaised;

        public void RaiseEvent(T value)
        {
            if (OnEventRaised == null) LogNoListeners();
            else OnEventRaised.Invoke(value);
        }
    }
}