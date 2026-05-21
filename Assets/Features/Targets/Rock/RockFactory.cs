using System.Collections.Generic;
using Core.Interfaces;
using VContainer;
using VContainer.Unity;

namespace Features.Targets.Rock
{
    public sealed class RockFactory : IRockFactory
    {
        private readonly IObjectResolver _resolver;
        private readonly IReadOnlyList<RockView> _views;
        private readonly IRockDurabilityProvider _durabilityProvider;

        public RockFactory(IObjectResolver resolver, IReadOnlyList<RockView> views, IRockDurabilityProvider durabilityProvider)
        {
            _resolver = resolver;
            _views = views;
            _durabilityProvider = durabilityProvider;
        }

        public ISpawnable Create()
        {
            var scope = _resolver.CreateScope(builder =>
            {
                var rng = new System.Random();

                builder.Register<IRockModel, RockModel>(Lifetime.Scoped)
                    .WithParameter("durability", _durabilityProvider.GetDurability());
                builder.RegisterComponentInNewPrefab(_views[rng.Next(_views.Count)], Lifetime.Scoped)
                    .AsImplementedInterfaces();
                builder.RegisterEntryPoint<RockController>(Lifetime.Scoped)
                    .As<ISpawnable>();
            });

            return scope.Resolve<ISpawnable>();
        }
    }
}