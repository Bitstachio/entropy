using UnityEngine;

namespace Features.Targets.Rock
{
    [CreateAssetMenu(fileName = "Rock Durability Config", menuName = "Targets/Rock/Rock Durability Config")]
    public sealed class RockDurabilityConfig : ScriptableObject
    {
        [Header("Base Durability")]
        [SerializeField] private float initialMean = 2.5f;
        [SerializeField] private float initialDeviation = 0.3f;

        [Header("Durability Progression Over Time")]
        [SerializeField] private float meanGrowthRate = 0.1f;
        [SerializeField] private float deviationGrowthRate = 0.05f;

        [Header("Durability Constraints")]
        [SerializeField] private float minDurability = 1f;
        [SerializeField] private float maxDurability = 50f;

        [Header("Spawn Interval")]
        [SerializeField] private float initialSpawnInterval = 8f;
        [SerializeField] private float spawnIntervalDecayRate = 0.01f;

        [Header("Spawn Interval Constraints")]
        [SerializeField] private float minSpawnInterval = 0.5f;
        [SerializeField] private float maxSpawnInterval = 10f;

        public float InitialMean => initialMean;
        public float InitialDeviation => initialDeviation;
        public float MeanGrowthRate => meanGrowthRate;
        public float DeviationGrowthRate => deviationGrowthRate;
        public float MinDurability => minDurability;
        public float MaxDurability => maxDurability;
        public float InitialSpawnInterval => initialSpawnInterval;
        public float SpawnIntervalDecayRate => spawnIntervalDecayRate;
        public float MinSpawnInterval => minSpawnInterval;
        public float MaxSpawnInterval => maxSpawnInterval;
    }
}
