using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Core.Upgrade;

namespace Features.Player.Attack.Cannon.Upgrade
{
    public sealed class CannonFireRateUpgrade : MultiplicativeUpgrade<CannonStats>
    {
        public CannonFireRateUpgrade(UpgradeDefinition definition, StatRegistry<CannonStats> stats)
            : base(definition, stats, CannonStats.Interval)
        {
        }
    }
}