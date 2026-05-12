using Features.Player.Upgrade.Strategies;

namespace Features.Player.Upgrade
{
    public interface IUpgrade : IUpgradeStrategy
    {
        UpgradeData Data { get; }
    }
}