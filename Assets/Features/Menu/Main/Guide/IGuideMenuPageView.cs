using System;
using Core.Interfaces;

namespace Features.Menu.Main.Guide
{
    public interface IGuideMenuPageView : IBackNavigablePageView
    {
        event Action OnMissionSelected;
        event Action OnDriverSystemSelected;
        event Action OnBlasterSelected;
        event Action OnLaserSelected;
        event Action OnShieldSelected;
    }
}