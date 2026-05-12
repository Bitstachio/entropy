using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Core.Utils
{
    public static class CollectionUtils
    {
        // TODO: Don't instantiate as field
        private static readonly Random Random = new();
        
        public static IList<T> GetRandomSubset<T>(this IList<T> source, int count)
        {
            if (count <= 0 || source.Count == 0) return new List<T>();
            
            var shuffled = new List<T>(source);
            for (var i = shuffled.Count - 1; i > 0; i--)
            {
                var j = Random.Next(i + 1);
                (shuffled[i], shuffled[j]) = (shuffled[j], shuffled[i]);
            }
        
            return shuffled.GetRange(0, Mathf.Min(count, shuffled.Count));
        }
    }
}