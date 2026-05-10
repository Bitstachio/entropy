using Core.ExtendedBehaviours;
using Core.Interfaces;
using Features.Player.Attack.Cannon.Interfaces;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Cannon
{
    public class CannonInstaller : Installer
    {
        [Header("Components")] [SerializeField]
        private CannonballView cannonballView;
        
        [Header("Spawn")]
        [SerializeField] private float interval;
        [SerializeField] private Transform origin;
        [SerializeField] private float speed; 
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent(cannonballView).As<ICannonballView>();

            builder.Register<IFactory, CannonballFactory>(Lifetime.Singleton);
            builder.RegisterEntryPoint<Cannon>()
                .WithParameter("interval", interval)
                .WithParameter("originPosition", origin.position)
                .WithParameter("speed", speed);
        }
    }
}