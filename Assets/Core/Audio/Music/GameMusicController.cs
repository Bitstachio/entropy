using System;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Services.Settings;
using UnityEngine;
using VContainer.Unity;

namespace Core.Audio.Music
{
    public sealed class GameMusicController : IStartable, IDisposable
    {
        private readonly IEventListener<GameOverEvent> _gameOverListener;
        private readonly ISettingsService _settingsService;

        private readonly IMusicPlayer _musicPlayer;
        private readonly AudioClip _clip;
        private readonly AudioClipData _data;

        public GameMusicController(
            IEventListener<GameOverEvent> gameOverListener,
            ISettingsService settingsService,
            IMusicPlayer musicPlayer,
            AudioClip clip,
            AudioClipData data)
        {
            _gameOverListener = gameOverListener;
            _settingsService = settingsService;
            _musicPlayer = musicPlayer;
            _clip = clip;
            _data = data;
        }

        //===== Lifecycle =====

        public void Start()
        {
            _gameOverListener.OnPublished += Stop;
            _settingsService.OnChanged += HandleSettingsChanged;
            _musicPlayer.Play(_clip, EffectiveVolume(_settingsService.Load()));
        }

        public void Dispose()
        {
            _gameOverListener.OnPublished -= Stop;
            _settingsService.OnChanged -= HandleSettingsChanged;
        }

        //===== Event Handlers =====

        private void HandleSettingsChanged(SettingsData settings) =>
            _musicPlayer.SetVolume(EffectiveVolume(settings));

        //===== Utilities =====

        private void Stop(GameOverEvent _) => _musicPlayer.Stop();

        private float EffectiveVolume(SettingsData settings) => _data.Volume * settings.MusicVolume;
    }
}
