using Core.StatRegistry;

namespace Core.Upgrade
{
    public sealed class MultiplicativeUpgrade<TStatKey> : Upgrade<TStatKey>
    {
        public MultiplicativeUpgrade(UpgradeDefinition definition, StatRegistry<TStatKey> stats, TStatKey key)
            : base(definition, stats, key)
        {
        }

        public override void Apply(float magnitude) => Stats.Register(Key, Stats.Retrieve(Key) * magnitude);
    }
}