using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Core.Upgrade;

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