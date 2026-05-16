using System.Collections.Generic;
using Core.Interfaces;

namespace Features.Player.Upgrade
{
    public interface IUpgradeView : IToggleable
    {
        void SetOptions(IEnumerable<UpgradeData> options);
    }
}