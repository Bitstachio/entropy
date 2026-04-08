namespace Core.Events.Interfaces
{
    public interface IEventPublisher
    {
        void Publish();
    }

    public interface IEventPublisher<in T>
    {
        void Publish(T value);
    }
}