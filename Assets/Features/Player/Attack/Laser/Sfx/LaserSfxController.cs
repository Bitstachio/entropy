using System;
using Core.Events.Channels;
using Core.Events.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Features.Player.Attack.Laser.Sfx
{
    public sealed class LaserSfxController : IStartable, IDisposable
    {
        private readonly IEventListener<LaserActivated> _laserActivatedListener;
        private readonly IEventListener<LaserDeactivated> _laserDeactivatedListener;
        
        private readonly AudioSource _audioSource;
        private readonly LaserSfxConfig _config;
        
        public LaserSfxController(
            IEventListener<LaserActivated> laserActivatedListener,
            IEventListener<LaserDeactivated> laserDeactivatedListener,
            AudioSource audioSource,
            LaserSfxConfig config)
        {
            _laserActivatedListener = laserActivatedListener;
            _laserDeactivatedListener = laserDeactivatedListener;
            _audioSource = audioSource;
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
            _audioSource.Stop();
            _audioSource.loop = false;
            
            _audioSource.PlayOneShot(_config.LaserStartClip);
            
            _audioSource.clip = _config.LaserActiveClip;
            _audioSource.loop = true;
            _audioSource.PlayDelayed(_config.LaserStartClip.length);
        }

        private void HandleLaserDeactivated(LaserDeactivated @event)
        {
            _audioSource.loop = false;
            _audioSource.Stop();
            _audioSource.PlayOneShot(_config.LaserEndClip);
        }
    }
}