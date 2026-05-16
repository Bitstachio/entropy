using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Upgrade.Strategies
{
    public sealed class CannonProjectileSpeedUpgrade : MultiplicativeUpgrade<CannonStats>
    {
        public CannonProjectileSpeedUpgrade(UpgradeDefinition definition, StatRegistry<CannonStats> stats)
            : base(definition, stats, CannonStats.ProjectileSpeed)
        {
        }
    }
}