using Core.StatRegistry;

namespace Features.Player.Upgrade.Strategies
{
    public abstract class Upgrade<TStatKey> : IUpgrade
    {
        public UpgradeData Data { get; }

        protected readonly StatRegistry<TStatKey> Stats;
        protected readonly TStatKey Key;

        protected Upgrade(UpgradeData data, StatRegistry<TStatKey> stats, TStatKey key)
        {
            Data = data;
            Stats = stats;
            Key = key;
        }

        public abstract void Apply(float magnitude);
    }
}