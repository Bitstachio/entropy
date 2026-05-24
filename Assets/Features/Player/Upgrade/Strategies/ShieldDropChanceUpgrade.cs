using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Upgrade.Strategies
{
    public sealed class ShieldDropChanceUpgrade : MultiplicativeUpgrade<ShieldStats>
    {
        public ShieldDropChanceUpgrade(UpgradeDefinition definition, StatRegistry<ShieldStats> stats)
            : base(definition, stats, ShieldStats.DropChance)
        {
        }
    }
}