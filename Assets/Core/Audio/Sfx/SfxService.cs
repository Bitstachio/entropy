using System;
using Core.Events.Channels;
using Core.Events.Interfaces;
using VContainer.Unity;

namespace Core.Audio.Sfx
{
    public sealed class SfxService : ISfxService, IStartable, IDisposable
    {
        private readonly IEventListener<GamePausedEvent> _gamePausedListener;
        private readonly IEventListener<GameResumedEvent> _gameResumedListener;
        private readonly IEventListener<GameOverEvent> _gameOverListener;

        private readonly ISfxPlayer _sfxPlayer;

        public SfxService(
            IEventListener<GamePausedEvent> gamePausedListener,
            IEventListener<GameResumedEvent> gameResumedListener,
            IEventListener<GameOverEvent> gameOverListener,
            ISfxPlayer sfxPlayer)
        {
            _gamePausedListener = gamePausedListener;
            _gameResumedListener = gameResumedListener;
            _gameOverListener = gameOverListener;
            _sfxPlayer = sfxPlayer;
        }

        //===== Lifecycle =====

        public void Start()
        {
            _gamePausedListener.OnPublished += HandleGamePaused;
            _gameResumedListener.OnPublished += HandleGameResumed;
            _gameOverListener.OnPublished += HandleGameOver;
        }

        public void Dispose()
        {
            _gamePausedListener.OnPublished -= HandleGamePaused;
            _gameResumedListener.OnPublished -= HandleGameResumed;
            _gameOverListener.OnPublished -= HandleGameOver;
        }

        //===== Event Handlers =====

        private void HandleGamePaused(GamePausedEvent _) => _sfxPlayer.Pause();

        private void HandleGameResumed(GameResumedEvent _) => _sfxPlayer.Resume();

        private void HandleGameOver(GameOverEvent _) => _sfxPlayer.Stop();
    }
}