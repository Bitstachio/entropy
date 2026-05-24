using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Upgrade.Strategies
{
    public sealed class ShieldDurationUpgrade : MultiplicativeUpgrade<ShieldStats>
    {
        public ShieldDurationUpgrade(UpgradeDefinition definition, StatRegistry<ShieldStats> stats)
            : base(definition, stats, ShieldStats.Duration)
        {
        }
    }
}