using System.Collections.Generic;
using Core.Interfaces;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Collectible
{
    public sealed class CollectibleFactory<TController> : ICollectibleFactory
    {
        private readonly IObjectResolver _resolver;
        private readonly CollectibleView _view;
        private readonly ISet<string> _collectorTags;
        
        public CollectibleFactory(IObjectResolver resolver, CollectibleView view, ISet<string> collectorTags)
        {
            _resolver = resolver;
            _view = view;
            _collectorTags = collectorTags;
        }

        public ISpawnable Create()
        {
            var scope = _resolver.CreateScope(builder =>
            {
                builder.RegisterComponentInNewPrefab(_view, Lifetime.Scoped)
                    .AsImplementedInterfaces();
                builder.RegisterEntryPoint<ShieldCollectibleController>(Lifetime.Scoped) // TODO: Incorporate `TController`
                    .WithParameter(_collectorTags)
                    .As<ISpawnable>();
            });

            return scope.Resolve<ISpawnable>();
        }
    }
}