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
        private readonly StatRegistry<CannonStats> _stats;
        private readonly IFactory _factory;
        private readonly IPositionProvider _positionProvider;

        private float _timer;

        public Cannon(StatRegistry<CannonStats> stats, IFactory factory, IPositionProvider positionProvider)
        {
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