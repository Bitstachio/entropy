using System;

namespace Core.Upgrade
{
    public interface IUpgradeInputHandler
    {
        event Action<int> OnOptionSelected;
    }
}