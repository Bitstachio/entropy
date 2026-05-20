using Core.Interfaces;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Collectible
{
    public sealed class CollectibleFactory<TController> : ICollectibleFactory
    {
        private readonly IObjectResolver _resolver;
        private readonly CollectibleView _view;
        
        public CollectibleFactory(IObjectResolver resolver, CollectibleView view)
        {
            _resolver = resolver;
            _view = view;
        }

        public ISpawnable Create()
        {
            var scope = _resolver.CreateScope(builder =>
            {
                builder.RegisterComponentInNewPrefab(_view, Lifetime.Scoped)
                    .AsImplementedInterfaces();
                builder.RegisterEntryPoint<ShieldCollectibleController>(Lifetime.Scoped) // TODO: Incorporate `TController`
                    .As<ISpawnable>();
            });

            return scope.Resolve<ISpawnable>();
        }
    }
}