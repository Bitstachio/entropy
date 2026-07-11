using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Core.Upgrade;

namespace Features.Player.Attack.Laser.Upgrade
{
    public sealed class LaserPulseIntervalUpgrade : MultiplicativeUpgrade<LaserBeamStats>
    {
        public LaserPulseIntervalUpgrade(UpgradeDefinition definition, StatRegistry<LaserBeamStats> stats)
            : base(definition, stats, LaserBeamStats.PulseInterval)
        {
        }
    }
}