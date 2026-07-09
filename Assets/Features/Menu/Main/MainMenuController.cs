using System;
using Core.Interfaces;
using Core.Services.Menu;
using Core.Services.Scene;
using VContainer.Unity;

namespace Features.Menu.Main
{
    public sealed class MainMenuController : IStartable, IDisposable
    {
        private readonly IMenuService _menuService;
        private readonly ISceneService _sceneService;

        private readonly MainMenuPages _pages;

        public MainMenuController(IMenuService menuService, ISceneService sceneService, MainMenuPages pages)
        {
            _menuService = menuService;
            _sceneService = sceneService;
            _pages = pages;
        }

        //===== Lifecycle =====

        public void Start()
        {
            _pages.Main.OnStartSelected += HandleStartSelected;
            _pages.Main.OnGuideSelected += HandleGuideSelected;
            _pages.Main.OnCreditsSelected += HandleCreditsSelected;

            _pages.Guide.OnBackSelected += HandleBackSelected;
            _pages.Credits.OnBackSelected += HandleBackSelected;
        }

        public void Dispose()
        {
            _pages.Main.OnStartSelected -= HandleStartSelected;
            _pages.Main.OnGuideSelected -= HandleGuideSelected;
            _pages.Main.OnCreditsSelected -= HandleCreditsSelected;

            _pages.Guide.OnBackSelected -= HandleBackSelected;
            _pages.Credits.OnBackSelected -= HandleBackSelected;
        }

        //===== Event Handlers =====

        private void HandleStartSelected() => _menuService.SelectOption(() => _sceneService.Load(Scenes.Game));

        private void HandleGuideSelected() => _menuService.SelectOption(() =>
        {
            _pages.Main.Off();
            _pages.Guide.On();
        });

        private void HandleCreditsSelected() => _menuService.SelectOption(() =>
        {
            _pages.Main.Off();
            _pages.Credits.On();
        });

        private void HandleBackSelected(IBackNavigablePageView view) => _menuService.SelectOption(() =>
        {
            _pages.Main.On();
            view.Off();
        });
    }
}