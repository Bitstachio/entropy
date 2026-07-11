using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Features.Player.Upgrade;
using Features.Player.Upgrade.Strategies;

namespace Features.Player.Shield.Upgrade
{
    public sealed class ShieldDropChanceUpgrade : MultiplicativeUpgrade<ShieldStats>
    {
        public ShieldDropChanceUpgrade(UpgradeDefinition definition, StatRegistry<ShieldStats> stats)
            : base(definition, stats, ShieldStats.DropChance)
        {
        }
    }
}