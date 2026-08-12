using Core.Interfaces;

namespace Features.Menu.Main.Guide
{
    public struct GuideMenuPages
    {
        public IGuideMenuPageView Menu { get; }
        public IBackNavigablePageView Mission { get; }
        public IBackNavigablePageView DriverSystem { get; }
        public IBackNavigablePageView Blaster { get; }
        public IBackNavigablePageView Laser { get; }
        public IBackNavigablePageView Shield { get; }

        public GuideMenuPages(
            IGuideMenuPageView menu,
            IBackNavigablePageView mission,
            IBackNavigablePageView driverSystem,
            IBackNavigablePageView blaster,
            IBackNavigablePageView laser,
            IBackNavigablePageView shield)
        {
            Menu = menu;
            Mission = mission;
            DriverSystem = driverSystem;
            Blaster = blaster;
            Laser = laser;
            Shield = shield;
        }
    }
}