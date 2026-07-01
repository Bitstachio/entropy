using System;
using Core.Events.Channels;
using Core.Events.Interfaces;
using VContainer.Unity;

namespace Features.Player.Attack.Laser.Animation
{
    public sealed class LaserAnimationController : IStartable, IDisposable
    {
        private readonly IEventListener<LaserDeactivated> _laserDeactivatedListener;
        private readonly ILaserAnimationView _view;

        public LaserAnimationController(
            IEventListener<LaserDeactivated> laserDeactivatedListener,
            ILaserAnimationView view)
        {
            _laserDeactivatedListener = laserDeactivatedListener;
            _view = view;
        }

        //===== Lifecycle =====

        public void Start() => _laserDeactivatedListener.OnPublished += HandleLaserDeactivated;

        public void Dispose() => _laserDeactivatedListener.OnPublished -= HandleLaserDeactivated;

        //===== Event Handlers =====

        private void HandleLaserDeactivated(LaserDeactivated @event) => _view.SetDeactivateTrigger();
    }
}