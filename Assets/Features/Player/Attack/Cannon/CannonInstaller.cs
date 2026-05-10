using Core.ExtendedBehaviours;
using Core.Interfaces;
using Core.Providers.Position;
using Features.Player.Attack.Cannon.Interfaces;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Cannon
{
    public class CannonInstaller : Installer
    {
        [Header("Prefabs")]
        [SerializeField] private CannonballView cannonballView;
        
        [Header("Providers")]
        [SerializeField] private TransformPositionProvider transformPositionProvider;
        
        [Header("Spawn")]
        [SerializeField] private float interval;
        [SerializeField] private float speed; 
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent(cannonballView).As<ICannonballView>();
            builder.RegisterComponent(transformPositionProvider).As<IPositionProvider>();

            builder.Register<IFactory, CannonballFactory>(Lifetime.Singleton);
            builder.RegisterEntryPoint<Cannon>()
                .WithParameter("interval", interval)
                .WithParameter("speed", speed);
        }
    }
}