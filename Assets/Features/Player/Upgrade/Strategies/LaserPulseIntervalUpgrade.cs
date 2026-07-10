using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Upgrade.Strategies
{
    public sealed class LaserPulseIntervalUpgrade : MultiplicativeUpgrade<LaserBeamStats>
    {
        public LaserPulseIntervalUpgrade(UpgradeDefinition definition, StatRegistry<LaserBeamStats> stats)
            : base(definition, stats, LaserBeamStats.PulseInterval)
        {
        }
    }
}