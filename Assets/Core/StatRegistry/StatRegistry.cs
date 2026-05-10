using System.Collections.Generic;

namespace Core.StatRegistry
{
    public class StatRegistry<TKey>
    {
        // TODO: Use a better data type than float for value
        private readonly Dictionary<TKey, float> stats = new();
        
        public void Register(TKey key, float value) => stats[key] = value;

        public float Retrieve(TKey key) => stats.GetValueOrDefault(key, 0f);
    }
}