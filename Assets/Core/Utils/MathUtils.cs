using System;

namespace Core.Utils
{
    public static class MathUtils
    {
        public static float SampleNormal(float mean, float deviation, Random rng = null)
        {
            rng ??= new Random();
    
            var u1 = 1.0 - rng.NextDouble();
            var u2 = 1.0 - rng.NextDouble();
            var standardNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
    
            return (float)(mean + deviation * standardNormal);
        }
    }
}