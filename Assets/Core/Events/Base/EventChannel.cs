using System;
using Core.Events.Interfaces;

namespace Core.Events.Base
{
    public class EventChannel<T> : EventChannelBase, IEventPublisher<T>, IEventListener<T>
    {
        public event Action<T> OnPublished;

        public void Publish(T value)
        {
            if (OnPublished == null) LogNoListeners();
            else OnPublished.Invoke(value);
        }
    }
}