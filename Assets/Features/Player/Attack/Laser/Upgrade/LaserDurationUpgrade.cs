using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Core.Upgrade;

namespace Features.Player.Attack.Laser.Upgrade
{
    public sealed class LaserDurationUpgrade : MultiplicativeUpgrade<LaserBeamStats>
    {
        public LaserDurationUpgrade(UpgradeDefinition definition, StatRegistry<LaserBeamStats> stats)
            : base(definition, stats, LaserBeamStats.Duration)
        {
        }
    }
}