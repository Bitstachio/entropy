using System;
using System.Collections.Generic;
using Core.Interfaces;

namespace Features.Player.Upgrade
{
    public interface IUpgradeView : IToggleable
    {
        event Action<int> OnUpgradeSelected;
        
        void SetOptions(IEnumerable<UpgradeData> options);
    }
}