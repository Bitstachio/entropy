using Core.ExtendedBehaviours;
using Features.StatDisplay.Controllers;
using Features.StatDisplay.Controllers.Shield;
using Features.StatDisplay.Controllers.Weapon;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.StatDisplay
{
    public class StatDisplayInstaller : Installer
    {
        [Header("Weapon Stats")]
        [SerializeField] private StatDisplayView cannonballDamageDisplayView;
        [SerializeField] private StatDisplayView cannonFireRateDisplayView;
        [SerializeField] private StatDisplayView cannonProjectileSpeedDisplayView;

        [Header("Shield Stats")]
        [SerializeField] private StatDisplayView shieldDurationDisplayView;
        [SerializeField] private StatDisplayView shieldDropChanceDisplayView;

        public override void Install(IContainerBuilder builder)
        {
            // Weapon stats
            builder.RegisterEntryPoint<CannonballDamageDisplayController>()
                .WithParameter<IStatDisplayView>(cannonballDamageDisplayView);
            builder.RegisterEntryPoint<CannonFireRateDisplayController>()
                .WithParameter<IStatDisplayView>(cannonFireRateDisplayView);
            builder.RegisterEntryPoint<CannonProjectileSpeedDisplayController>()
                .WithParameter<IStatDisplayView>(cannonProjectileSpeedDisplayView);

            // Shield stats
            builder.RegisterEntryPoint<ShieldDurationDisplayController>()
                .WithParameter<IStatDisplayView>(shieldDurationDisplayView);
            builder.RegisterEntryPoint<ShieldDropChanceDisplayController>()
                .WithParameter<IStatDisplayView>(shieldDropChanceDisplayView);
        }
    }
}