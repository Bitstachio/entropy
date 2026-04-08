using System;
using Core.Events.Interfaces;
using UnityEngine;

namespace Core.Events.Base
{
    public abstract class EventChannel : EventChannelBase, IEventPublisher, IEventListener
    {
        public event Action OnPublished;

        public void Publish()
        {
            if (OnPublished == null) LogNoListeners();
            else OnPublished.Invoke();
        }
    }

    public abstract class EventChannel<T> : EventChannelBase, IEventPublisher<T>, IEventListener<T>
    {
        public event Action<T> OnPublished;

        public void Publish(T value)
        {
            Debug.Log("Event Published!"); // TODO: Remove
            if (OnPublished == null) LogNoListeners();
            else OnPublished.Invoke(value);
        }
    }
}