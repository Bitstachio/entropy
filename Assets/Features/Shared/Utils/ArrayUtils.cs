using System;

namespace Features.Shared.Utils
{
    public static class ArrayUtils
    {
        public static void Shuffle<T>(T[] array, Random rng)
        {
            for (var i = array.Length - 1; i > 0; i--)
            {
                var j = rng.Next(i + 1);
                (array[i], array[j]) = (array[j], array[i]);
            }
        }
    }
}