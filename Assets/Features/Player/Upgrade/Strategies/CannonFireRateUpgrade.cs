using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Upgrade.Strategies
{
    public sealed class CannonFireRateUpgrade : MultiplicativeUpgrade<CannonStats>
    {
        public CannonFireRateUpgrade(UpgradeDefinition definition, StatRegistry<CannonStats> stats)
            : base(definition, stats, CannonStats.Interval)
        {
        }
    }
}