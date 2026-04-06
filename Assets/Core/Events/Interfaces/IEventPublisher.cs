namespace Core.Events.Interfaces
{
    public interface IEventPublisher
    {
        void Publish();
    }

    public interface IEventPublisher<T>
    {
        void Publish(T value);
    }
}