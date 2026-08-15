using System;
using Core.Interfaces;
using Core.Services.Menu;
using VContainer.Unity;

namespace Features.Menu.Main.Guide
{
    public sealed class GuideMenuController : IStartable, IDisposable
    {
        private readonly IMenuService _menuService;

        private readonly GuideMenuPages _pages;

        public GuideMenuController(IMenuService menuService, GuideMenuPages pages)
        {
            _menuService = menuService;
            _pages = pages;
        }

        //===== Lifecycle =====

        public void Start()
        {
            _pages.Menu.OnMissionSelected += HandleMissionSelected;
            _pages.Menu.OnDriverSystemSelected += HandleDriverSystemSelected;
            _pages.Menu.OnBlasterSelected += HandleBlasterSelected;
            _pages.Menu.OnLaserSelected += HandleLaserSelected;
            _pages.Menu.OnShieldSelected += HandleShieldSelected;

            _pages.Mission.OnBackSelected += HandleBackSelected;
            _pages.DriverSystem.OnBackSelected += HandleBackSelected;
            _pages.Blaster.OnBackSelected += HandleBackSelected;
            _pages.Laser.OnBackSelected += HandleBackSelected;
            _pages.Shield.OnBackSelected += HandleBackSelected;
        }

        public void Dispose()
        {
            _pages.Menu.OnMissionSelected -= HandleMissionSelected;
            _pages.Menu.OnDriverSystemSelected -= HandleDriverSystemSelected;
            _pages.Menu.OnBlasterSelected -= HandleBlasterSelected;
            _pages.Menu.OnLaserSelected -= HandleLaserSelected;
            _pages.Menu.OnShieldSelected -= HandleShieldSelected;

            _pages.Mission.OnBackSelected -= HandleBackSelected;
            _pages.DriverSystem.OnBackSelected -= HandleBackSelected;
            _pages.Blaster.OnBackSelected -= HandleBackSelected;
            _pages.Laser.OnBackSelected -= HandleBackSelected;
            _pages.Shield.OnBackSelected -= HandleBackSelected;
        }

        //===== Lifecycle =====

        private void HandleBackSelected(IBackNavigablePageView view) => _menuService.SelectOption(() =>
        {
            view.Off();
            _pages.Menu.On();
        });

        private void HandleMissionSelected() => _menuService.SelectOption(() =>
        {
            _pages.Menu.Off();
            _pages.Mission.On();
        });

        private void HandleDriverSystemSelected() => _menuService.SelectOption(() =>
        {
            _pages.Menu.Off();
            _pages.DriverSystem.On();
        });

        private void HandleBlasterSelected() => _menuService.SelectOption(() =>
        {
            _pages.Menu.Off();
            _pages.Blaster.On();
        });

        private void HandleLaserSelected() => _menuService.SelectOption(() =>
        {
            _pages.Menu.Off();
            _pages.Laser.On();
        });

        private void HandleShieldSelected() => _menuService.SelectOption(() =>
        {
            _pages.Menu.Off();
            _pages.Shield.On();
        });
    }
}