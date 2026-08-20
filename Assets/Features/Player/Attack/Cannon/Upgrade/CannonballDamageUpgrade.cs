using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Core.Upgrade;

namespace Features.Player.Attack.Cannon.Upgrade
{
    public sealed class CannonballDamageUpgrade : MultiplicativeUpgrade<CannonStats>
    {
        public CannonballDamageUpgrade(UpgradeDefinition definition, StatRegistry<CannonStats> stats)
            : base(definition, stats, CannonStats.Damage)
        {
        }
    }
}