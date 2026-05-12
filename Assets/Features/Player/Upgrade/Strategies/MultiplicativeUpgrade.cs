using Core.StatRegistry;

namespace Features.Player.Upgrade.Strategies
{
    public class MultiplicativeUpgrade<TStatKey> : Upgrade<TStatKey>
    {
        protected MultiplicativeUpgrade(UpgradeData data, StatRegistry<TStatKey> stats, TStatKey key)
            : base(data, stats, key)
        {
        }

        public override void Apply(float magnitude) => Stats.Register(Key, Stats.Retrieve(Key) * magnitude);
    }
}