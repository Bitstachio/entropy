using System.Collections.Generic;

namespace Features.Player.Upgrade
{
    public interface IUpgradeRegistry
    {
        public IList<IUpgrade> GetRandomSubset(int count);
    }
}