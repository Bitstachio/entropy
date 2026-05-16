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

        // TODO: Consider adapting a variation of MVP pattern to handle upgrade magnitude formatting
        public static string FormatMagnitude(float magnitude) => magnitude < 1
            ? $"-{(int)((1 - magnitude) * 100 + 0.5)}%"
            : $"+{(int)((magnitude - 1) * 100 + 0.5)}%";
    }
}