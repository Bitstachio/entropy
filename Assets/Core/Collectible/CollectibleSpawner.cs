using Core.Foundations.EntryPoints;
using Core.Providers.Bounds;
using UnityEngine;
using Random = System.Random;

namespace Core.Collectible
{
    public sealed class CollectibleSpawner : StochasticTickable
    {
        private readonly ICollectibleFactory _factory;
        private readonly IBoundsProvider _boundsProvider;
        private readonly CollectibleSpawnConfig _spawnConfig;
        private readonly Vector3 _origin;

        public CollectibleSpawner(
            ICollectibleFactory factory,
            IBoundsProvider boundsProvider,
            CollectibleSpawnConfig spawnConfig,
            Vector3 origin)
            : base(new Random(), spawnConfig.Probability, spawnConfig.Interval)
        {
            _boundsProvider = boundsProvider;
            _factory = factory;
            _spawnConfig = spawnConfig;
            _origin = origin;
        }

        //===== Utilities =====

        protected override void Execute()
        {
            var x = UnityEngine.Random.Range(_boundsProvider.Min, _boundsProvider.Max);
            var position = new Vector2(x, _origin.y);
            var horizontalSpeed = UnityEngine.Random.Range(-_spawnConfig.XSpeedBound, _spawnConfig.XSpeedBound);

            var spawnable = _factory.Create();
            spawnable.SetPosition(position);
            spawnable.SetVelocity(new Vector2(horizontalSpeed, 0));
        }
    }
}