using System.Collections.Generic;
using Core.Utils;
using Features.Player.Upgrade.Strategies;

namespace Features.Player.Upgrade
{
    public class UpgradeRegistry : IUpgradeRegistry
    {
        private readonly IList<IUpgrade> _upgrades;
        
        public UpgradeRegistry(IList<IUpgrade> upgrades) => _upgrades = upgrades;

        public IList<IUpgrade> GetRandomSubset(int count) => _upgrades.GetRandomSubset(count);
    }
}