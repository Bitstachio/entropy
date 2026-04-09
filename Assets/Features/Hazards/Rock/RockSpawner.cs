using Features.Hazards.Rock.Interfaces;
using Features.Shared.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Features.Hazards.Rock
{
    public sealed class RockSpawner : ITickable
    {
        private readonly IBoundsProvider _boundsProvider;
        private readonly IRockFactory _rockFactory;
        private readonly Vector3 _originPosition;
        private readonly float _interval;
        private readonly float _xSpeedBound;

        private float _timer;

        public RockSpawner(
            IBoundsProvider boundsProvider,
            IRockFactory rockFactory,
            Vector3 originPosition,
            float interval,
            float xSpeedBound)
        {
            _boundsProvider = boundsProvider;
            _rockFactory = rockFactory;
            _originPosition = originPosition;
            _interval = interval;
            _xSpeedBound = xSpeedBound;
        }

        public void Tick()
        {
            _timer += Time.deltaTime;
            if (_timer < _interval) return;

            var x = Random.Range(_boundsProvider.Min, _boundsProvider.Max);
            var position = new Vector2(x, _originPosition.y);
            var horizontalSpeed = Random.Range(-_xSpeedBound, _xSpeedBound);

            var spawnable = _rockFactory.Create();
            spawnable.SetPosition(position);
            spawnable.SetVelocity(new Vector2(horizontalSpeed, 0));

            _timer = 0f;
        }
    }
}