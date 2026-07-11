using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Features.Player.Upgrade;
using Features.Player.Upgrade.Strategies;

namespace Features.Player.Shield.Upgrade
{
    public sealed class ShieldDurationUpgrade : MultiplicativeUpgrade<ShieldStats>
    {
        public ShieldDurationUpgrade(UpgradeDefinition definition, StatRegistry<ShieldStats> stats)
            : base(definition, stats, ShieldStats.Duration)
        {
        }
    }
}