using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Upgrade.Strategies
{
    public class CannonballDamageUpgrade : MultiplicativeUpgrade<CannonballStats>
    {
        public CannonballDamageUpgrade(UpgradeData data, StatRegistry<CannonballStats> stats, CannonballStats key)
            : base(data, stats, key)
        {
        }
    }
}