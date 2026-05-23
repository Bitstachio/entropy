using UnityEngine;

namespace Core.Validators
{
    public static class NumericValidator
    {
        public static float ValidateProbability(float probability)
        {
            if (probability is >= 0 and <= 1) return probability;
            Debug.LogError($"Probability must be between 0 and 1. {probability} given.");
            return 0;
        }
    }
}