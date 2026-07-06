using System;
using Core.Constants;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Services.Scene;
using VContainer.Unity;

namespace Features.Menu.GameOver
{
    public sealed class GameOverMenuController : IStartable, IDisposable
    {
        private readonly IEventPublisher<MenuOptionSelected> _menuOptionSelectedPublisher;

        private readonly IGameOverMenuModel _model;
        private readonly IGameOverMenuView _view;

        public GameOverMenuController(
            IEventPublisher<MenuOptionSelected> menuOptionSelectedPublisher,
            IGameOverMenuModel model,
            IGameOverMenuView view)
        {
            _menuOptionSelectedPublisher = menuOptionSelectedPublisher;
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
            MenuUtils.SelectScene(Scenes.Game, _menuOptionSelectedPublisher, _model.SceneLoadDelay);

        private void HandleHomeSelected() =>
            MenuUtils.SelectScene(Scenes.Main, _menuOptionSelectedPublisher, _model.SceneLoadDelay);
    }
}