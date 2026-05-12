using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Upgrade.Strategies
{
    public sealed class CannonFireRateUpgrade : MultiplicativeUpgrade<CannonStats>
    {
        public CannonFireRateUpgrade(UpgradeData data, StatRegistry<CannonStats> stats)
            : base(data, stats, CannonStats.Interval)
        {
        }
    }
}