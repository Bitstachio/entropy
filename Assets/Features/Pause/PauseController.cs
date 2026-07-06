using System;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Services.TimeScale;
using VContainer.Unity;

namespace Features.Pause
{
    public sealed class PauseController : IStartable, IDisposable
    {
        private readonly IEventPublisher<GamePausedEvent> _gamePausedPublisher;
        private readonly IEventPublisher<GameResumedEvent> _gameResumedPublisher;

        private readonly ITimeScaleService _timeScaleService;

        private readonly IPauseView _view;
        private readonly IPauseInputHandler _input;

        public PauseController(
            IEventPublisher<GamePausedEvent> gamePausedPublisher,
            IEventPublisher<GameResumedEvent> gameResumedPublisher,
            ITimeScaleService timeScaleService,
            IPauseView view,
            IPauseInputHandler input)
        {
            _gamePausedPublisher = gamePausedPublisher;
            _gameResumedPublisher = gameResumedPublisher;
            _timeScaleService = timeScaleService;
            _view = view;
            _input = input;
        }

        //===== Lifecycle =====

        public void Start() => _input.OnPauseToggleInputDetected += HandlePauseToggleInputDetected;

        public void Dispose() => _input.OnPauseToggleInputDetected -= HandlePauseToggleInputDetected;

        //===== Event Handlers =====

        private void HandlePauseToggleInputDetected()
        {
            if (_timeScaleService.IsPaused) Resume();
            else Pause();
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