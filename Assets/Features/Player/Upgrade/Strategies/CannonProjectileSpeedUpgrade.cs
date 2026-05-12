using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Upgrade.Strategies
{
    public sealed class CannonProjectileSpeedUpgrade : MultiplicativeUpgrade<CannonStats>
    {
        public CannonProjectileSpeedUpgrade(UpgradeData data, StatRegistry<CannonStats> stats)
            : base(data, stats, CannonStats.ProjectileSpeed)
        {
        }
    }
}