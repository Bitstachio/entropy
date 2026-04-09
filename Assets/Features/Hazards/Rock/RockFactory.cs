using Core.Interactions;
using Features.Hazards.Rock.Interfaces;
using VContainer;
using VContainer.Unity;

namespace Features.Hazards.Rock
{
    public sealed class RockFactory : IRockFactory
    {
        private readonly IObjectResolver _resolver;
        private readonly RockView _view;

        public RockFactory(IObjectResolver resolver, RockView view)
        {
            _resolver = resolver;
            _view = view;
        }

        public ISpawnable Create()
        {
            var scope = _resolver.CreateScope(builder =>
            {
                builder.Register<IRockModel, RockModel>(Lifetime.Scoped)
                    .WithParameter("durability", 3f); // TODO: Remove hard-coded value
                builder.RegisterComponentInNewPrefab(_view, Lifetime.Scoped)
                    .AsImplementedInterfaces();
                builder.RegisterEntryPoint<RockController>(Lifetime.Scoped)
                    .As<ISpawnable>();
            });

            return scope.Resolve<ISpawnable>();
        }
    }
}