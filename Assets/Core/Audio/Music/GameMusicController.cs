using System;
using Core.Events.Channels;
using Core.Events.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Core.Audio.Music
{
    public sealed class GameMusicController : IStartable, IDisposable
    {
        private readonly IEventListener<GameOverEvent> _gameOverListener;

        private readonly IMusicPlayer _musicPlayer;
        private readonly AudioClip _clip;
        private readonly AudioClipConfig _config;

        public GameMusicController(
            IEventListener<GameOverEvent> gameOverListener,
            IMusicPlayer musicPlayer,
            AudioClip clip,
            AudioClipConfig config)
        {
            _gameOverListener = gameOverListener;
            _musicPlayer = musicPlayer;
            _clip = clip;
            _config = config;
        }

        //===== Lifecycle =====

        public void Start()
        {
            _gameOverListener.OnPublished += Stop;
            _musicPlayer.Play(_clip, _config.Volume);
        }

        public void Dispose() => _gameOverListener.OnPublished -= Stop;

        //===== Utilities =====

        private void Stop(GameOverEvent _) => _musicPlayer.Stop();
    }
}