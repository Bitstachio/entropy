using System.Collections.Generic;
using Core.Interfaces;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Blaster
{
    public sealed class BoltFactory : IFactory
    {
        private readonly IObjectResolver _resolver;
        private readonly BoltView _view;
        private readonly ISet<string> _destroyTags;

        public BoltFactory(IObjectResolver resolver, BoltView view, ISet<string> destroyTags)
        {
            _resolver = resolver;
            _view = view;
            _destroyTags = destroyTags;
        }

        public ISpawnable Create()
        {
            var scope = _resolver.CreateScope(builder =>
            {
                builder.Register<IBoltModel, BoltModel>(Lifetime.Scoped);
                builder.RegisterComponentInNewPrefab(_view, Lifetime.Scoped).AsImplementedInterfaces();
                builder.RegisterEntryPoint<BoltController>(Lifetime.Scoped).As<ISpawnable>()
                    .WithParameter(_destroyTags);
            });

            return scope.Resolve<ISpawnable>();
        }
    }
}
