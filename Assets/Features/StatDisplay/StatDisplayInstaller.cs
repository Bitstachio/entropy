using Core.ExtendedBehaviours;
using Features.StatDisplay.Controllers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.StatDisplay
{
    public class StatDisplayInstaller : Installer
    {
        [Header("Components")]
        [SerializeField] private StatDisplayView cannonballDamageDisplayView;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent(cannonballDamageDisplayView);
            builder.RegisterEntryPoint<CannonballDamageDisplayController>()
                .WithParameter<IStatDisplayView>(cannonballDamageDisplayView);
        }
    }
}