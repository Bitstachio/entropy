using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Upgrade.Strategies
{
    public sealed class CannonballDamageUpgrade : MultiplicativeUpgrade<CannonballStats>
    {
        public CannonballDamageUpgrade(UpgradeDefinition definition, StatRegistry<CannonballStats> stats)
            : base(definition, stats, CannonballStats.Damage)
        {
        }
    }
}