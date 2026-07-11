using System.Collections.Generic;
using System.Linq;

namespace Features.Player.Upgrade
{
    public sealed class UpgradeRegistry : IUpgradeRegistry
    {
        public IList<IUpgrade> Upgrades { get; }
        
        // TODO: Temporary fix; investigate if list conversion is correct or if I should transition to IEnumerable
        public UpgradeRegistry(IEnumerable<IUpgrade> upgrades) => Upgrades = upgrades.ToList();
    }
}