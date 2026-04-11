using System;

namespace Core.Events.Interfaces
{
    public interface IEventListener<out T>
    {
        event Action<T> OnPublished;
    }
}