using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Movement
{
    public sealed class MovementScope : LifetimeScope
    {
        [Header("Components")]
        [SerializeField] private MovementView movementView;

        [Header("Stats")]
        [SerializeField] private float baselineTopSpeed = 5f;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterBuildCallback(container =>
            {
                var movementStats = container.Resolve<StatRegistry<MovementStats>>();
                movementStats.Register(MovementStats.TopSpeed, baselineTopSpeed);
            });

            builder.Register<IMovementModel, MovementModel>(Lifetime.Singleton);
            builder.RegisterComponent(movementView).As<IMovementView>();
            builder.RegisterEntryPoint<MovementController>();
        }
    }
}