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
        /// Maps a normalized value (0-1) to a discrete step count.
        /// </summary>
        /// <param name="normalizedValue">The input value to map, clamped between 0 and 1.</param>
        /// <param name="stepCount">The total number of available steps.</param>
        /// <param name="roundUp">If true, uses CeilToInt (nonzero yields >= 1 step). If false, uses FloorToInt.</param>
        /// <returns>The calculated discrete step count.</returns>
        public static int NormalizedToStepCount(float normalizedValue, int stepCount, bool roundUp = true)
        {
            var clampedValue = Mathf.Clamp01(normalizedValue);
            var scaledValue = clampedValue * stepCount;

            return roundUp ? Mathf.CeilToInt(scaledValue) : Mathf.FloorToInt(scaledValue);
        }
    }
}