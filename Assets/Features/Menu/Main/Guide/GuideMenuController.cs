using System;
using Core.Interfaces;
using Core.Services.Menu;
using UnityEngine;
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
            _pages.Menu.On();
            view.Off();
        });

        private void HandleMissionSelected() => _menuService.SelectOption(() =>
        {
            Debug.Log("Mission selected!");
            _pages.Mission.On();
            _pages.Menu.Off();
        });

        private void HandleDriverSystemSelected() => _menuService.SelectOption(() =>
        {
            _pages.DriverSystem.On();
            _pages.Menu.Off();
        });

        private void HandleBlasterSelected() => _menuService.SelectOption(() =>
        {
            _pages.Blaster.On();
            _pages.Menu.Off();
        });

        private void HandleLaserSelected() => _menuService.SelectOption(() =>
        {
            _pages.Laser.On();
            _pages.Menu.Off();
        });

        private void HandleShieldSelected() => _menuService.SelectOption(() =>
        {
            _pages.Shield.On();
            _pages.Menu.Off();
        });
    }
}