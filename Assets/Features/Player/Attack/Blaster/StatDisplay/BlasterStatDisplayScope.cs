using Core.StatDisplay;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Blaster.StatDisplay
{
    public sealed class BlasterStatDisplayScope : LifetimeScope
    {
        [FormerlySerializedAs("cannonballDamageDisplayView")]
        [SerializeField] private StatDisplayView blasterDamageDisplayView;
        [FormerlySerializedAs("cannonFireRateDisplayView")]
        [SerializeField] private StatDisplayView blasterFireRateDisplayView;
        [FormerlySerializedAs("cannonProjectileSpeedDisplayView")]
        [SerializeField] private StatDisplayView blasterProjectileSpeedDisplayView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<BlasterDamageDisplayController>()
                .WithParameter<IStatDisplayView>(blasterDamageDisplayView);
            builder.RegisterEntryPoint<BlasterFireRateDisplayController>()
                .WithParameter<IStatDisplayView>(blasterFireRateDisplayView);
            builder.RegisterEntryPoint<BlasterProjectileSpeedDisplayController>()
                .WithParameter<IStatDisplayView>(blasterProjectileSpeedDisplayView);
        }
    }
}
