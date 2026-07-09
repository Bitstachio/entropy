using System;
using Core.Services.Menu;
using Core.Services.Scene;
using VContainer.Unity;

namespace Features.Menu.GameOver
{
    public sealed class GameOverMenuController : IStartable, IDisposable
    {
        private readonly IMenuService _menuService;
        private readonly ISceneService _sceneService;

        private readonly IGameOverMenuModel _model;
        private readonly IGameOverMenuView _view;

        public GameOverMenuController(
            IMenuService menuService,
            ISceneService sceneService,
            IGameOverMenuModel model,
            IGameOverMenuView view)
        {
            _menuService = menuService;
            _sceneService = sceneService;
            _model = model;
            _view = view;
        }

        //===== Lifecycle =====

        public void Start()
        {
            _view.OnRetrySelected += HandleRetrySelected;
            _view.OnHomeSelected += HandleHomeSelected;

            // TODO: Consider decoupling presentation logic from controller
            _view.SetScore($"{_model.Score} Pts");
            _view.SetHighScore($"{_model.HighScore} Pts");
            _view.SetDatabaseStatus(_model.IsNewHighScore ? "[NEW BEST RECORD ESTABLISHED]" : "[NO CHANGE]");
        }

        public void Dispose()
        {
            _view.OnRetrySelected -= HandleRetrySelected;
            _view.OnHomeSelected -= HandleHomeSelected;
        }

        //===== Event Handlers =====

        private void HandleRetrySelected() =>
            _menuService.SelectOption(() => _sceneService.Load(Scenes.Game));

        private void HandleHomeSelected() =>
            _menuService.SelectOption(() => _sceneService.Load(Scenes.Main));
    }
}