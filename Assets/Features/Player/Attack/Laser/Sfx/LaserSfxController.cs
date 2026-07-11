using System;
using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Services.Settings;
using VContainer.Unity;

namespace Features.Player.Attack.Laser.Sfx
{
    public sealed class LaserSfxController : IStartable, IDisposable
    {
        private readonly IEventListener<LaserActivated> _laserActivatedListener;
        private readonly IEventListener<LaserDeactivated> _laserDeactivatedListener;

        private readonly ISettingsService _settingsService;

        private readonly ISfxPlayer _sfxPlayer;
        private readonly LaserSfxConfig _config;

        public LaserSfxController(
            IEventListener<LaserActivated> laserActivatedListener,
            IEventListener<LaserDeactivated> laserDeactivatedListener,
            ISettingsService settingsService,
            ISfxPlayer sfxPlayer,
            LaserSfxConfig config)
        {
            _laserActivatedListener = laserActivatedListener;
            _laserDeactivatedListener = laserDeactivatedListener;
            _settingsService = settingsService;
            _sfxPlayer = sfxPlayer;
            _config = config;
        }

        //===== Lifecycle =====

        public void Start()
        {
            _laserActivatedListener.OnPublished += HandleLaserActivated;
            _laserDeactivatedListener.OnPublished += HandleLaserDeactivated;
        }

        public void Dispose()
        {
            _laserActivatedListener.OnPublished -= HandleLaserActivated;
            _laserDeactivatedListener.OnPublished -= HandleLaserDeactivated;
        }

        //===== Lifecycle =====

        private void HandleLaserActivated(LaserActivated @event)
        {
            var sfxVolume = _settingsService.Load().SfxVolume;
            _sfxPlayer.PlayOneShot(_config.StartClipData.Clip, _config.StartClipData.Volume * sfxVolume);
            _sfxPlayer.PlayLooped(
                _config.ActiveClipData.Clip,
                _config.ActiveClipData.Volume * sfxVolume,
                _config.StartClipData.Clip.length);
        }

        private void HandleLaserDeactivated(LaserDeactivated @event)
        {
            _sfxPlayer.Stop();
            _sfxPlayer.PlayOneShot(
                _config.EndClipData.Clip,
                _config.EndClipData.Volume * _settingsService.Load().SfxVolume);
        }
    }
}