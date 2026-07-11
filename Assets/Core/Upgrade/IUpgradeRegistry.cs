using System.Collections.Generic;

namespace Core.Upgrade
{
    public interface IUpgradeRegistry
    {
        public IList<IUpgrade> Upgrades { get; }
    }
}