using System.Collections.Generic;
using System.Linq;
using Core.Utils;

namespace Features.Player.Upgrade
{
    public static class UpgradeUtils
    {
        public static IReadOnlyList<UpgradeOption> PrepOptions(IList<IUpgrade> upgrades, int count)
        {
            var magnitude = 10f; // TODO: Remove hard-coded magnitude

            // TODO: Precondition checking for count
            return upgrades
                .GetRandomSubset(count)
                .Select(u => new UpgradeOption(
                    new UpgradeCommand(u, magnitude),
                    new UpgradeData(u.Definition.Title, u.Definition.Icon, magnitude)))
                .ToList();
        }
    }
}