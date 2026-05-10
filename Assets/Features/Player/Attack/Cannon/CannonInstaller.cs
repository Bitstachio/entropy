using Core.ExtendedBehaviours;
using Core.Interfaces;
using Core.Providers.Position;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Features.Player.Attack.Cannon.Interfaces;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Cannon
{
    public sealed class CannonInstaller : Installer
    {
        [Header("Prefabs")]
        [SerializeField] private CannonballView cannonballView;
        
        [Header("Providers")]
        [SerializeField] private TransformPositionProvider transformPositionProvider;
        
        [Header("Stats")]
        [SerializeField] private float baselineInterval;
        [SerializeField] private float baselineSpeed; 
        
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<StatRegistry<CannonStats>>(Lifetime.Singleton);
            builder.RegisterBuildCallback(container =>
            {
                var statRegistry = container.Resolve<StatRegistry<CannonStats>>();
                statRegistry.Register(CannonStats.Interval, baselineInterval);
                statRegistry.Register(CannonStats.Speed, baselineSpeed);
            });
            
            builder.RegisterComponent(cannonballView).As<ICannonballView>();
            builder.RegisterComponent(transformPositionProvider).As<IPositionProvider>();

            builder.Register<IFactory, CannonballFactory>(Lifetime.Singleton);
            builder.RegisterEntryPoint<Cannon>()
                .WithParameter("interval", baselineInterval)
                .WithParameter("speed", baselineSpeed);
        }
    }
}