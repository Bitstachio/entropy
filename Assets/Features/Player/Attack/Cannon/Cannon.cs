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
    public sealed class Cannon : ITickable
    {
        private readonly IEventPublisher<CannonShotEvent> _cannonShotPublisher;

        private readonly StatRegistry<CannonStats> _stats;
        private readonly IFactory _factory;
        private readonly IPositionProvider _positionProvider;

        private float _timer;

        public Cannon(
            IEventPublisher<CannonShotEvent> cannonShotPublisher,
            StatRegistry<CannonStats> stats,
            IFactory factory,
            IPositionProvider positionProvider)
        {
            _cannonShotPublisher = cannonShotPublisher;
            _stats = stats;
            _factory = factory;
            _positionProvider = positionProvider;
        }

        //===== Lifecycle =====

        public void Tick()
        {
            _timer += Time.deltaTime;
            if (_timer < _stats.Retrieve(CannonStats.Interval)) return;
            Spawn();
            _cannonShotPublisher.Publish(new CannonShotEvent());
            _timer = 0;
        }

        //===== Utilities =====

        private void Spawn()
        {
            var spawnable = _factory.Create();
            spawnable.SetPosition(_positionProvider.Position);
            spawnable.SetVelocity(new Vector2(0, _stats.Retrieve(CannonStats.ProjectileSpeed)));
        }
    }
}