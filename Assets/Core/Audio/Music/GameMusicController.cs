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
        private readonly AudioClipData data;

        public GameMusicController(
            IEventListener<GameOverEvent> gameOverListener,
            IMusicPlayer musicPlayer,
            AudioClip clip,
            AudioClipData data)
        {
            _gameOverListener = gameOverListener;
            _musicPlayer = musicPlayer;
            _clip = clip;
            this.data = data;
        }

        //===== Lifecycle =====

        public void Start()
        {
            _gameOverListener.OnPublished += Stop;
            _musicPlayer.Play(_clip, data.Volume);
        }

        public void Dispose() => _gameOverListener.OnPublished -= Stop;

        //===== Utilities =====

        private void Stop(GameOverEvent _) => _musicPlayer.Stop();
    }
}