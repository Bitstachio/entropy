using UnityEngine;

namespace Features.Targets.Rock
{
    [CreateAssetMenu(fileName = "Rock Durability Config", menuName = "Targets/Rock/Rock Durability Config")]
    public sealed class RockDurabilityConfig : ScriptableObject
    {
        [Header("Base Durability")]
        [SerializeField] private float initialMean = 3f;
        [SerializeField] private float initialDeviation = 0.5f;

        [Header("Progression Over Time")]
        [SerializeField] private float meanGrowthRate = 0.5f;
        [SerializeField] private float deviationGrowthRate = 0.2f;

        [Header("Constraints")]
        [SerializeField] private float minDurability = 1f;
        [SerializeField] private float maxDurability = 50f;

        public float InitialMean => initialMean;
        public float InitialDeviation => initialDeviation;
        public float MeanGrowthRate => meanGrowthRate;
        public float DeviationGrowthRate => deviationGrowthRate;
        public float MinDurability => minDurability;
        public float MaxDurability => maxDurability;
    }
}
