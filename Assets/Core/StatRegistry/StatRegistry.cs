using System.Collections.Generic;
using Core.Events.Channels;
using Core.Events.Interfaces;

namespace Core.StatRegistry
{
    public class StatRegistry<TKey>
    {
        // TODO: Use a better data type than float for value
        private readonly Dictionary<TKey, float> stats = new();
        private readonly IEventPublisher<StatRegistryUpdatedEvent<TKey>> _publisher;

        public StatRegistry(IEventPublisher<StatRegistryUpdatedEvent<TKey>> publisher) => _publisher = publisher;

        public void Register(TKey key, float value)
        {
            _publisher.Publish(new StatRegistryUpdatedEvent<TKey>(key, stats.GetValueOrDefault(key, 0f), value));
            stats[key] = value;
        }

        public float Retrieve(TKey key) => stats.GetValueOrDefault(key, 0f);
    }
}