using System;
using UnityEngine;
using Random = System.Random;

namespace Core.Utils
{
    public static class MathUtils
    {
        /// <summary>
        /// Returns a random value centered around <paramref name="mean"/> with a variance of
        /// <paramref name="deviation"/>. Use this instead of `Random.Range` when you want
        /// natural-feeling variation rather than uniform randomness.
        /// </summary>
        public static float SampleNormal(float mean, float deviation, Random rng = null)
        {
            rng ??= new Random();

            var u1 = 1.0 - rng.NextDouble();
            var u2 = 1.0 - rng.NextDouble();
            var standardNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);

            return (float)(mean + deviation * standardNormal);
        }

        /// <summary>
        /// Maps a normalized value (0-1) to a discrete step count, rounding up so any nonzero
        /// value yields at least one step. E.g. with 5 steps: 0.9 -> 5, 0.4 -> 2, 0.05 -> 1.
        /// </summary>
        public static int NormalizedToStepCount(float normalizedValue, int stepCount)
        {
            var clampedValue = Mathf.Clamp01(normalizedValue);
            return Mathf.CeilToInt(clampedValue * stepCount);
        }
        
        public static int NormalizedToStepCount1(float normalizedValue, int stepCount)
        {
            var clampedValue = Mathf.Clamp01(normalizedValue);
            return Mathf.FloorToInt(clampedValue * stepCount);
        }
    }
}