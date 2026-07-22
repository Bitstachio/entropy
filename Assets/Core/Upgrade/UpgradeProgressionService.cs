using UnityEngine;

namespace Core.Upgrade
{
    public sealed class UpgradeProgressionService : IUpgradeProgressionService
    {
        public float CurrentTime { get; private set; }
        public float TargetInterval { get; }
        public float ProgressRatio => Mathf.Clamp01(CurrentTime / TargetInterval);
        public bool IsIntervalReached => CurrentTime >= TargetInterval;

        public UpgradeProgressionService(UpgradeControllerConfig config) => TargetInterval = config.Interval;

        //===== API =====

        public void Tick(float deltaTime) => CurrentTime += deltaTime;

        public void Reset() => CurrentTime = 0f;
    }
}