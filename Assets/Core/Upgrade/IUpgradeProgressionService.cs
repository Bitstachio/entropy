namespace Core.Upgrade
{
    public interface IUpgradeProgressionService
    {
        float CurrentTime { get; }
        float TargetInterval { get; }
        float ProgressRatio { get; }
        bool IsIntervalReached { get; }

        void Tick(float deltaTime);
        void Reset();
    }
}