using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Core.Upgrade;

namespace Features.Player.Attack.Cannon.Upgrade
{
    public sealed class CannonballDamageUpgrade : MultiplicativeUpgrade<CannonballStats>
    {
        public CannonballDamageUpgrade(UpgradeDefinition definition, StatRegistry<CannonballStats> stats)
            : base(definition, stats, CannonballStats.Damage)
        {
        }
    }
}