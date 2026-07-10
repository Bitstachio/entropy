using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Upgrade.Strategies
{
    public sealed class LaserDurationUpgrade : MultiplicativeUpgrade<LaserBeamStats>
    {
        public LaserDurationUpgrade(UpgradeDefinition definition, StatRegistry<LaserBeamStats> stats)
            : base(definition, stats, LaserBeamStats.Duration)
        {
        }
    }
}