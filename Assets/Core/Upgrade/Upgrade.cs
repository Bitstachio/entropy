using Core.StatRegistry;

namespace Core.Upgrade
{
    public abstract class Upgrade<TStatKey> : IUpgrade
    {
        public UpgradeDefinition Definition { get; }

        protected readonly StatRegistry<TStatKey> Stats;
        protected readonly TStatKey Key;

        protected Upgrade(UpgradeDefinition definition, StatRegistry<TStatKey> stats, TStatKey key)
        {
            Definition = definition;
            Stats = stats;
            Key = key;
        }

        public abstract void Apply(float magnitude);
    }
}