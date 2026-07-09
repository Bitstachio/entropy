using System;
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
        }

        public void Dispose()
        {
            _pages.Main.OnStartSelected -= HandleStartSelected;
            _pages.Main.OnGuideSelected -= HandleGuideSelected;
            _pages.Main.OnCreditsSelected -= HandleCreditsSelected;
        }

        //===== Event Handlers =====

        private void HandleStartSelected() => _menuService.SelectOption(() => _sceneService.Load(Scenes.Game));

        private void HandleGuideSelected()
        {
        }

        private void HandleCreditsSelected()
        {
        }
    }
}