using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Features.Player.Upgrade;
using Features.Player.Upgrade.Strategies;

namespace Features.Player.Attack.Cannon.Upgrade
{
    public sealed class CannonProjectileSpeedUpgrade : MultiplicativeUpgrade<CannonStats>
    {
        public CannonProjectileSpeedUpgrade(UpgradeDefinition definition, StatRegistry<CannonStats> stats)
            : base(definition, stats, CannonStats.ProjectileSpeed)
        {
        }
    }
}