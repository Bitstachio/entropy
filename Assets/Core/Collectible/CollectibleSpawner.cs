using Core.Foundations.EntryPoints;
using Core.Providers.Bounds;
using UnityEngine;
using Random = System.Random;

namespace Core.Collectible
{
    public sealed class CollectibleSpawner : StochasticTickable
    {
        private readonly IBoundsProvider _boundsProvider;
        private readonly ICollectibleFactory _factory; // TODO: Change to IFactory
        private readonly Vector3 _originPosition;
        private readonly float _xSpeedBound;

        public CollectibleSpawner(
            IBoundsProvider boundsProvider,
            ICollectibleFactory factory,
            Vector3 originPosition,
            float interval,
            float xSpeedBound)
            : base(new Random(), 0.1f, interval) // TODO: Remove hard-coded interval
        {
            _boundsProvider = boundsProvider;
            _factory = factory;
            _originPosition = originPosition;
            _xSpeedBound = xSpeedBound;
        }

        //===== Utilities =====

        protected override void Execute()
        {
            var x = UnityEngine.Random.Range(_boundsProvider.Min, _boundsProvider.Max);
            var position = new Vector2(x, _originPosition.y);
            var horizontalSpeed = UnityEngine.Random.Range(-_xSpeedBound, _xSpeedBound);

            var spawnable = _factory.Create();
            spawnable.SetPosition(position);
            spawnable.SetVelocity(new Vector2(horizontalSpeed, 0));
        }
    }
}