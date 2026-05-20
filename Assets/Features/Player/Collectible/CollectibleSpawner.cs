using Core.Providers.Bounds;
using UnityEngine;
using VContainer.Unity;

namespace Features.Player.Collectible
{
    public sealed class CollectibleSpawner : ITickable
    {
        private readonly IBoundsProvider _boundsProvider;
        private readonly ICollectibleFactory _factory;
        private readonly Vector3 _originPosition;
        private readonly float _interval;
        private readonly float _xSpeedBound;

        private float _timer;

         public CollectibleSpawner(
            IBoundsProvider boundsProvider,
            ICollectibleFactory factory,
            Vector3 originPosition,
            float interval,
            float xSpeedBound)
        {
            _boundsProvider = boundsProvider;
            _factory = factory;
            _originPosition = originPosition;
            _interval = interval;
            _xSpeedBound = xSpeedBound;
        }

        //===== Lifecycle =====

        public void Tick()
        {
            _timer += Time.deltaTime;
            if (_timer < _interval) return;

            var x = Random.Range(_boundsProvider.Min, _boundsProvider.Max);
            var position = new Vector2(x, _originPosition.y);
            var horizontalSpeed = Random.Range(-_xSpeedBound, _xSpeedBound);

            var spawnable = _factory.Create();
            spawnable.SetPosition(position);
            spawnable.SetVelocity(new Vector2(horizontalSpeed, 0));

            _timer = 0f;
        }
    }
}