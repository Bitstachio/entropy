using Core.ExtendedBehaviours;
using Core.StatRegistry;
using Features.Player.Movement.Interfaces;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Movement
{
    public class MovementInstaller : Installer
    {
        [Header("Components")]
        [SerializeField] private MovementView movementView;
        
        [Header("Stats")]
        [SerializeField] private float baselineTopSpeed = 5f;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<StatRegistry<Core.StatRegistry.StatKeys.Movement>>(Lifetime.Singleton);
            
            builder.Register<IMovementModel, MovementModel>(Lifetime.Singleton)
                .WithParameter(baselineTopSpeed);
            builder.RegisterComponent(movementView).As<IMovementView>();
            builder.RegisterEntryPoint<MovementController>();
        }
    }
}