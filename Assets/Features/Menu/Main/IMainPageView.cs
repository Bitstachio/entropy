using System;
using Core.Interfaces;

namespace Features.Menu.Main
{
    public interface IMainPageView : IToggleable
    {
        event Action OnStartSelected;
        event Action OnGuideSelected;
        event Action OnCreditsSelected;
    }
}