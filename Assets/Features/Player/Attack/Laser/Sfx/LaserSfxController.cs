using System;
using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;
using VContainer.Unity;

namespace Features.Player.Attack.Laser.Sfx
{
    public sealed class LaserSfxController : IStartable, IDisposable
    {
        private readonly IEventListener<LaserActivated> _laserActivatedListener;
        private readonly IEventListener<LaserDeactivated> _laserDeactivatedListener;

        private readonly ISfxPlayer _sfxPlayer;
        private readonly LaserSfxConfig _config;

        public LaserSfxController(
            IEventListener<LaserActivated> laserActivatedListener,
            IEventListener<LaserDeactivated> laserDeactivatedListener,
            ISfxPlayer sfxPlayer,
            LaserSfxConfig config)
        {
            _laserActivatedListener = laserActivatedListener;
            _laserDeactivatedListener = laserDeactivatedListener;
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

        // TODO: Remove hard-coded volumes

        private void HandleLaserActivated(LaserActivated @event)
        {
            _sfxPlayer.PlayOneShot(_config.LaserStartClip, 1f);
            _sfxPlayer.PlayLooped(_config.LaserActiveClip, 1f, _config.LaserStartClip.length);
        }

        private void HandleLaserDeactivated(LaserDeactivated @event)
        {
            _sfxPlayer.Stop();
            _sfxPlayer.PlayOneShot(_config.LaserEndClip, 1f);
        }
    }
}