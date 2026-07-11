using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Features.Player.Upgrade;
using Features.Player.Upgrade.Strategies;

namespace Features.Player.Attack.Laser.Upgrade
{
    public sealed class LaserDamageUpgrade : MultiplicativeUpgrade<LaserBeamStats>
    {
        public LaserDamageUpgrade(UpgradeDefinition definition, StatRegistry<LaserBeamStats> stats)
            : base(definition, stats, LaserBeamStats.DamagePerPulse)
        {
        }
    }
}