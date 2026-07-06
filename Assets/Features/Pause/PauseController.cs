using System;
using Core.Constants;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Services.TimeScale;
using Features.Menu;
using VContainer.Unity;

namespace Features.Pause
{
    public sealed class PauseController : IStartable, IDisposable
    {
        private readonly IEventPublisher<GamePausedEvent> _gamePausedPublisher;
        private readonly IEventPublisher<GameResumedEvent> _gameResumedPublisher;
        private readonly IEventPublisher<MenuOptionSelected> _menuOptionSelectedPublisher;

        private readonly ITimeScaleService _timeScaleService;

        private readonly IPauseView _view;
        private readonly IPauseInputHandler _input;

        public PauseController(
            IEventPublisher<GamePausedEvent> gamePausedPublisher,
            IEventPublisher<GameResumedEvent> gameResumedPublisher,
            IEventPublisher<MenuOptionSelected> menuOptionSelectedPublisher,
            ITimeScaleService timeScaleService,
            IPauseView view,
            IPauseInputHandler input)
        {
            _gamePausedPublisher = gamePausedPublisher;
            _gameResumedPublisher = gameResumedPublisher;
            _menuOptionSelectedPublisher = menuOptionSelectedPublisher;
            _timeScaleService = timeScaleService;
            _view = view;
            _input = input;
        }

        //===== Lifecycle =====

        public void Start()
        {
            _input.OnPauseToggleInputDetected += HandlePauseToggleInputDetected;
            _view.OnResumeSelected += HandleResumeSelected;
            _view.OnSettingsSelected += HandleSettingsSelected;
            _view.OnRestartSelected += HandleRestartSelected;
            _view.OnAbortSelected += HandleAbortSelected;
        }

        public void Dispose()
        {
            _input.OnPauseToggleInputDetected -= HandlePauseToggleInputDetected;
            _view.OnResumeSelected -= HandleResumeSelected;
            _view.OnSettingsSelected -= HandleSettingsSelected;
            _view.OnRestartSelected -= HandleRestartSelected;
            _view.OnAbortSelected -= HandleAbortSelected;
        }

        //===== Event Handlers =====

        private void HandlePauseToggleInputDetected()
        {
            if (_timeScaleService.IsPaused) Resume();
            else Pause();
        }

        private void HandleResumeSelected() => Resume();

        private void HandleSettingsSelected()
        {
        }

        private void HandleRestartSelected()
        {
            MenuUtils.SelectScene(Scenes.Game, _menuOptionSelectedPublisher, 200);
            _timeScaleService.Resume();
        }

        private void HandleAbortSelected()
        {
            MenuUtils.SelectScene(Scenes.Main, _menuOptionSelectedPublisher, 200);
            _timeScaleService.Resume();
        }

        //===== Utilities =====

        private void Pause()
        {
            _timeScaleService.Pause();
            _view.On();

            _gamePausedPublisher.Publish(new GamePausedEvent());
        }

        private void Resume()
        {
            _timeScaleService.Resume();
            _view.Off();

            _gameResumedPublisher.Publish(new GameResumedEvent());
        }
    }
}