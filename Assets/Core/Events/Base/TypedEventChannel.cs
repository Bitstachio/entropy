using System;
using Core.Events.Interfaces;

namespace Core.Events.Base
{
    public abstract class TypedEventChannel<T> : EventChannelBase, IEventPublisher<T>
    {
        public event Action<T> OnPublished;

        public void Publish(T value)
        {
            if (OnPublished == null) LogNoListeners();
            else OnPublished.Invoke(value);
        }
    }
}