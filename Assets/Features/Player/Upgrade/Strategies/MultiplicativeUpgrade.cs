using Core.StatRegistry;

namespace Features.Player.Upgrade.Strategies
{
    public class MultiplicativeUpgrade<TStatKey> : UpgradeStrategy<TStatKey>
    {
        protected MultiplicativeUpgrade(StatRegistry<TStatKey> stats, TStatKey key) : base(stats, key)
        {
        }

        public override void Apply(float magnitude) => Stats.Register(Key, Stats.Retrieve(Key) * magnitude);
    }
}