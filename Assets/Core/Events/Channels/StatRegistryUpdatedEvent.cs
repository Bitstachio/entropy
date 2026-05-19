namespace Core.Events.Channels
{
    public struct StatRegistryUpdatedEvent<T>
    {
        public T Key { get; }
        public float PrevValue { get; }
        public float NewValue { get; }

        public StatRegistryUpdatedEvent(T key, float prevValue, float newValue)
        {
            Key = key;
            PrevValue = prevValue;
            NewValue = newValue;
        }
    }
}