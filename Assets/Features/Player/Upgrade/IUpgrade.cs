using Features.Player.Upgrade.Strategies;

namespace Features.Player.Upgrade
{
    public interface IUpgrade : IUpgradeStrategy
    {
        UpgradeDefinition Definition { get; }
    }
}