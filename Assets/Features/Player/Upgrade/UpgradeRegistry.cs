using System.Collections.Generic;

namespace Features.Player.Upgrade
{
    public sealed class UpgradeRegistry : IUpgradeRegistry
    {
        public UpgradeRegistry(IList<IUpgrade> upgrades) => Upgrades = upgrades;

        public IList<IUpgrade> Upgrades { get; }
    }
}