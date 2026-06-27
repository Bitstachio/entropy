using Core.Foundations.Components;
using Core.StatDisplay;
using Features.StatDisplay;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Cannon.StatDisplay
{
    public sealed class CannonStatDisplayInstaller : Installer
    {
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