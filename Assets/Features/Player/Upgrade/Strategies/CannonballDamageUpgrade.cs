using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Upgrade.Strategies
{
    public sealed class CannonballDamageUpgrade : MultiplicativeUpgrade<CannonballStats>
    {
        public CannonballDamageUpgrade(UpgradeData data, StatRegistry<CannonballStats> stats)
            : base(data, stats, CannonballStats.Damage)
        {
        }
    }
}