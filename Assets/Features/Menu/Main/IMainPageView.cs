using System;

namespace Features.Menu.Main
{
    public interface IMainPageView
    {
        event Action OnStartSelected;
        event Action OnGuideSelected;
        event Action OnCreditsSelected;
    }
}