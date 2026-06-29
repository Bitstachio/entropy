using Core.StatDisplay;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Cannon.StatDisplay
{
    public sealed class CannonStatDisplayScope : LifetimeScope
    {
        [SerializeField] private StatDisplayView cannonballDamageDisplayView;
        [SerializeField] private StatDisplayView cannonFireRateDisplayView;
        [SerializeField] private StatDisplayView cannonProjectileSpeedDisplayView;
        
        protected override void Configure(IContainerBuilder builder)
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