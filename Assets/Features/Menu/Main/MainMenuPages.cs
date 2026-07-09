using Core.Interfaces;

namespace Features.Menu.Main
{
    public struct MainMenuPages
    {
        public IMainPageView Main { get; }
        public IBackNavigablePageView Guide { get; }
        public IBackNavigablePageView Credits { get; }

        public MainMenuPages(
            IMainPageView main,
            IBackNavigablePageView guide,
            IBackNavigablePageView credits)
        {
            Main = main;
            Guide = guide;
            Credits = credits;
        }
    }
}