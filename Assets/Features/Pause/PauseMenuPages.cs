using Core.Interfaces;

namespace Features.Pause
{
    public struct PauseMenuPages
    {
        public IToggleable Main { get; }
        public IBackNavigablePageView Settings { get; }
        
        public PauseMenuPages(IToggleable main, IBackNavigablePageView settings)
        {
            Main = main;
            Settings = settings;
        }
    }
}