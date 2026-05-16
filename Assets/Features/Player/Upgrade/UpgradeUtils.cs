using System.Collections.Generic;
using System.Linq;
using Core.Utils;

namespace Features.Player.Upgrade
{
    public static class UpgradeUtils
    {
        public static IReadOnlyList<UpgradeOption> PrepOptions(IList<IUpgrade> upgrades, int count)
        {
            return upgrades
                .GetRandomSubset(count)
                .Select(u =>
                {
                    var magnitude = MathUtils.SampleNormal(u.Definition.Mean, u.Definition.Deviation);
                    return new UpgradeOption(
                        new UpgradeCommand(u, magnitude),
                        new UpgradeData(u.Definition.Title, u.Definition.Icon, magnitude));
                })
                .ToList();
        }
    }
}