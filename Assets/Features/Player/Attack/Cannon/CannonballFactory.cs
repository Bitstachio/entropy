using System.Collections.Generic;
using Core.Interactions;
using Core.Interfaces;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Features.Player.Attack.Cannon.Interfaces;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Cannon
{
    public sealed class CannonballFactory : IFactory
    {
        private readonly StatRegistry<CannonballStats> _stats;
        private readonly IObjectResolver _resolver;
        private readonly CannonballView _view;
        private readonly ISet<string> _destroyTags;

        public CannonballFactory(StatRegistry<CannonballStats> stats, IObjectResolver resolver, CannonballView view,
            ISet<string> destroyTags)
        {
            _stats = stats;
            _resolver = resolver;
            _view = view;
            _destroyTags = destroyTags;
        }

        public ISpawnable Create()
        {
            var scope = _resolver.CreateScope(builder =>
            {
                builder.Register<ICannonballModel, CannonballModel>(Lifetime.Scoped)
                    .WithParameter(_stats.Retrieve(CannonballStats.Damage));
                builder.RegisterComponentInNewPrefab(_view, Lifetime.Scoped).AsImplementedInterfaces();
                builder.RegisterEntryPoint<CannonballController>(Lifetime.Scoped).As<ISpawnable>()
                    .WithParameter(_destroyTags);
            });

            return scope.Resolve<ISpawnable>();
        }
    }
}