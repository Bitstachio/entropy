using System;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Interfaces;
using Core.Providers.Position;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using UnityEngine;
using VContainer.Unity;

namespace Features.Player.Attack.Cannon
{
    public sealed class Cannon : IStartable, IDisposable, ITickable
    {
        private readonly IEventPublisher<CannonShotEvent> _cannonShotPublisher;
        // Cannon deactivates when the laser is activated
        private readonly IEventListener<LaserActivated> _laserActivatedListener;
        private readonly IEventListener<LaserDeactivated> _laserDeactivatedListener;

        private readonly StatRegistry<CannonStats> _stats;
        private readonly IFactory _factory;
        private readonly IPositionProvider _positionProvider;

        private float _timer;
        private bool _isActive = true;

        public Cannon(
            IEventPublisher<CannonShotEvent> cannonShotPublisher,
            IEventListener<LaserActivated> laserActivatedListener,
            IEventListener<LaserDeactivated> laserDeactivatedListener,
            StatRegistry<CannonStats> stats,
            IFactory factory,
            IPositionProvider positionProvider)
        {
            _cannonShotPublisher = cannonShotPublisher;
            _laserActivatedListener = laserActivatedListener;
            _laserDeactivatedListener = laserDeactivatedListener;
            _stats = stats;
            _factory = factory;
            _positionProvider = positionProvider;
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

        public void Tick()
        {
            if (!_isActive) return;
            
            _timer += Time.deltaTime;
            
            if (_timer < _stats.Retrieve(CannonStats.Interval)) return;
            Spawn();
            _cannonShotPublisher.Publish(new CannonShotEvent());
            _timer = 0;
        }

        //===== Event Handlers =====

        private void HandleLaserActivated(LaserActivated @event) => Deactivate();

        private void HandleLaserDeactivated(LaserDeactivated @event) => Activate();

        //===== Utilities =====

        private void Activate()
        {
            _isActive = true;
            _timer = 0;
        }

        private void Deactivate() => _isActive = false;

        private void Spawn()
        {
            var spawnable = _factory.Create();
            spawnable.SetPosition(_positionProvider.Position);
            spawnable.SetVelocity(new Vector2(0, _stats.Retrieve(CannonStats.ProjectileSpeed)));
        }
    }
}