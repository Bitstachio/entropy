using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Upgrade.Strategies
{
    public sealed class LaserDamageUpgrade : MultiplicativeUpgrade<LaserBeamStats>
    {
        public LaserDamageUpgrade(UpgradeDefinition definition, StatRegistry<LaserBeamStats> stats)
            : base(definition, stats, LaserBeamStats.DamagePerPulse)
        {
        }
    }
}