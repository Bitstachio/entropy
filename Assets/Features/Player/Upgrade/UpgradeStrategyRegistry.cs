using System.Collections.Generic;
using Core.Utils;
using Features.Player.Upgrade.Strategies;

namespace Features.Player.Upgrade
{
    public class UpgradeStrategyRegistry
    {
        private readonly IList<IUpgradeStrategy> _strategies;
        
        public UpgradeStrategyRegistry(IList<IUpgradeStrategy> strategies) => _strategies = strategies;

        public IList<IUpgradeStrategy> GetRandomSubset(int count) => _strategies.GetRandomSubset(count);
    }
}