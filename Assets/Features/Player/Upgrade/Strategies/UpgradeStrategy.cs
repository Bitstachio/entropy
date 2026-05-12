using Core.StatRegistry;

namespace Features.Player.Upgrade.Strategies
{
    public abstract class UpgradeStrategy<TStatKey> : IUpgradeStrategy
    {
        protected readonly StatRegistry<TStatKey> Stats;
        protected readonly TStatKey Key;

        protected UpgradeStrategy(StatRegistry<TStatKey> stats, TStatKey key)
        {
            Stats = stats;
            Key = key;
        }
        
        public abstract void Apply(float magnitude);
    }
}