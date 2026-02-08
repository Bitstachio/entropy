using Shared.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Features.Hazards.Scripts
{
    public sealed class RockSpawner : ITickable
    {
        private readonly IBoundsProvider _boundsProvider;
        private readonly RockFactory _rockFactory;
        private readonly Vector3 _originPosition;
        private readonly float _interval;
        private readonly float _xSpeedBound;

        private float _timer;

        public RockSpawner(
            IBoundsProvider boundsProvider,
            RockFactory rockFactory,
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
            var position = new Vector3(x, _originPosition.y, 0);
            var rock = _rockFactory.Create(position);

            var horizontalSpeed = Random.Range(-_xSpeedBound, _xSpeedBound);
            var rb = rock.GetComponent<Rigidbody2D>();
            if (rb != null) rb.linearVelocity = new Vector2(horizontalSpeed, rb.linearVelocity.y);

            _timer = 0f;
        }
    }
}