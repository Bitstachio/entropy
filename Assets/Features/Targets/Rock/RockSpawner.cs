using Core.Providers.Bounds;
using UnityEngine;
using VContainer.Unity;

namespace Features.Targets.Rock
{
    public sealed class RockSpawner : ITickable
    {
        private readonly IBoundsProvider _boundsProvider;
        private readonly IRockFactory _rockFactory;
        private readonly RockDurabilityConfig _config;
        private readonly Vector3 _originPosition;
        private readonly float _xSpeedBound;

        private float _timer;

        public RockSpawner(
            IBoundsProvider boundsProvider,
            IRockFactory rockFactory,
            RockDurabilityConfig config,
            Vector3 originPosition,
            float xSpeedBound)
        {
            _boundsProvider = boundsProvider;
            _rockFactory = rockFactory;
            _config = config;
            _originPosition = originPosition;
            _xSpeedBound = xSpeedBound;
        }

        public void Tick()
        {
            _timer += Time.deltaTime;

            var currentInterval = CalculateCurrentInterval();
            if (_timer < currentInterval) return;

            var x = Random.Range(_boundsProvider.Min, _boundsProvider.Max);
            var position = new Vector2(x, _originPosition.y);
            var horizontalSpeed = Random.Range(-_xSpeedBound, _xSpeedBound);

            var spawnable = _rockFactory.Create();
            spawnable.SetPosition(position);
            spawnable.SetVelocity(new Vector2(horizontalSpeed, 0));

            _timer = 0f;
        }

        private float CalculateCurrentInterval()
        {
            var elapsedTime = Time.time;
            var interval = _config.InitialSpawnInterval - _config.SpawnIntervalDecayRate * elapsedTime;
            return Mathf.Clamp(interval, _config.MinSpawnInterval, _config.MaxSpawnInterval);
        }
    }
}