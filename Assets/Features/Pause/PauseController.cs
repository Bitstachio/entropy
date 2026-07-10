using System;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Interfaces;
using Core.Services.Menu;
using Core.Services.Scene;
using Core.Services.TimeScale;
using VContainer.Unity;

namespace Features.Pause
{
    public sealed class PauseController : IStartable, IDisposable
    {
        private readonly IEventPublisher<GamePausedEvent> _gamePausedPublisher;
        private readonly IEventPublisher<GameResumedEvent> _gameResumedPublisher;

        private readonly IMenuService _menuService;
        private readonly ITimeScaleService _timeScaleService;
        private readonly ISceneService _sceneService;

        private readonly IPauseView _view;
        private readonly IPauseInputHandler _input;
        private readonly PauseMenuPages _pages;

        public PauseController(
            IEventPublisher<GamePausedEvent> gamePausedPublisher,
            IEventPublisher<GameResumedEvent> gameResumedPublisher,
            IMenuService menuService,
            ITimeScaleService timeScaleService,
            ISceneService sceneService,
            IPauseView view,
            IPauseInputHandler input,
            PauseMenuPages pages)
        {
            _gamePausedPublisher = gamePausedPublisher;
            _gameResumedPublisher = gameResumedPublisher;
            _menuService = menuService;
            _timeScaleService = timeScaleService;
            _sceneService = sceneService;
            _view = view;
            _input = input;
            _pages = pages;
        }

        //===== Lifecycle =====

        public void Start()
        {
            _input.OnPauseToggleInputDetected += HandlePauseToggleInputDetected;

            _view.OnResumeSelected += HandleResumeSelected;
            _view.OnSettingsSelected += HandleSettingsSelected;
            _view.OnRestartSelected += HandleRestartSelected;
            _view.OnAbortSelected += HandleAbortSelected;

            _pages.Settings.OnBackSelected += HandleBackSelected;
        }

        public void Dispose()
        {
            _input.OnPauseToggleInputDetected -= HandlePauseToggleInputDetected;

            _view.OnResumeSelected -= HandleResumeSelected;
            _view.OnSettingsSelected -= HandleSettingsSelected;
            _view.OnRestartSelected -= HandleRestartSelected;
            _view.OnAbortSelected -= HandleAbortSelected;

            _pages.Settings.OnBackSelected += HandleBackSelected;
        }

        //===== Event Handlers =====

        private void HandlePauseToggleInputDetected()
        {
            if (_timeScaleService.IsPaused) Resume();
            else Pause();
        }

        private void HandleResumeSelected() => _menuService.SelectOption(Resume);

        private void HandleSettingsSelected() => _menuService.SelectOption(() =>
        {
            _pages.Main.Off();
            _pages.Settings.On();
        });

        private void HandleRestartSelected() => _menuService.SelectOption(() => _sceneService.Load(Scenes.Game));

        private void HandleAbortSelected() => _menuService.SelectOption(() => _sceneService.Load(Scenes.Main));

        private void HandleBackSelected(IBackNavigablePageView view) => _menuService.SelectOption(() =>
        {
            _pages.Main.On();
            view.Off();
        });

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