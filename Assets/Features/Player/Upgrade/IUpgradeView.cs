using System.Collections.Generic;

namespace Features.Player.Upgrade
{
    public interface IUpgradeView
    {
        void SetOptions(IEnumerable<UpgradeData> options);
    }
}