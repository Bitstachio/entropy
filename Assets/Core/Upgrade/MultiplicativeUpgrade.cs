using Core.StatRegistry;

namespace Core.Upgrade
{
    public abstract class MultiplicativeUpgrade<TStatKey> : Upgrade<TStatKey>
    {
        protected MultiplicativeUpgrade(UpgradeDefinition definition, StatRegistry<TStatKey> stats, TStatKey key)
            : base(definition, stats, key)
        {
        }

        public override void Apply(float magnitude) => Stats.Register(Key, Stats.Retrieve(Key) * magnitude);
    }
}