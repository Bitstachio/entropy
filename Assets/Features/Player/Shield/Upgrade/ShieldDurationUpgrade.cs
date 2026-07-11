using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Core.Upgrade;

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