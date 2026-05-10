using Core.Interactions;
using Core.Interfaces;
using Features.Player.Attack.Cannon.Interfaces;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Cannon
{
    public sealed class CannonballFactory : IFactory
    {
        private readonly IObjectResolver _resolver;
        private readonly CannonballView _view;

        public CannonballFactory(IObjectResolver resolver, CannonballView view)
        {
            _resolver = resolver;
            _view = view;
        }

        public ISpawnable Create()
        {
            var scope = _resolver.CreateScope(builder =>
            {
                builder.Register<ICannonballModel, CannonballModel>(Lifetime.Scoped)
                    .WithParameter("damage", 1f); // TODO: Don't hardcode
                builder.RegisterComponentInNewPrefab(_view, Lifetime.Scoped).AsImplementedInterfaces();
                builder.RegisterEntryPoint<CannonballController>(Lifetime.Scoped).As<ISpawnable>()
                    .WithParameter("boundaryTag", "Boundary"); // TODO: Don't hardcode
            });

            return scope.Resolve<ISpawnable>();
        }
    }
}