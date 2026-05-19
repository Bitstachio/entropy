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
        [SerializeField] private StatDisplayView cannonFireRateDisplayView;
        [SerializeField] private StatDisplayView cannonProjectileSpeedDisplayView;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<CannonballDamageDisplayController>()
                .WithParameter<IStatDisplayView>(cannonballDamageDisplayView);
            builder.RegisterEntryPoint<CannonFireRateDisplayController>()
                .WithParameter<IStatDisplayView>(cannonFireRateDisplayView);
            builder.RegisterEntryPoint<CannonProjectileSpeedDisplayController>()
                .WithParameter<IStatDisplayView>(cannonProjectileSpeedDisplayView);
        }
    }
}