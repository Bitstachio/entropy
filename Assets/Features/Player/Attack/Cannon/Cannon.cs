using Core.Interfaces;
using Core.Providers.Position;
using UnityEngine;
using VContainer.Unity;

namespace Features.Player.Attack.Cannon
{
    public sealed class Cannon : ITickable
    {
        private readonly IFactory _factory;
        private readonly IPositionProvider _positionProvider;
        private readonly float _interval;
        private readonly float _speed;

        private float _timer;

        public Cannon(IFactory factory, IPositionProvider positionProvider, float interval, float speed)
        {
            _factory = factory;
            _positionProvider = positionProvider;
            _interval = interval;
            _speed = speed;
        }

        //===== Lifecycle =====

        public void Tick()
        {
            _timer += Time.deltaTime;
            if (_timer < _interval) return;
            Spawn();
            _timer = 0;
        }

        //===== Utilities =====

        private void Spawn()
        {
            var spawnable = _factory.Create();
            spawnable.SetPosition(_positionProvider.Position);
            spawnable.SetVelocity(new Vector2(0, _speed));
        }
    }
}