using System;

namespace Core.Events.Interfaces
{
    public interface IEventSubscriber
    {
        void Subscribe(Action handler);
        void Unsubscribe(Action handler);
    }

    public interface IEventSubscriber<T>
    {
        void Subscribe(Action<T> handler);
        void Unsubscribe(Action<T> handler);
    }
}