using Core.StatDisplay;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Laser.StatDisplay
{
    public sealed class LaserStatDisplayScope : LifetimeScope
    {
        [SerializeField] private StatDisplayView damagePerPulseDisplayView;
        [SerializeField] private StatDisplayView pulseIntervalDisplayView;
        [SerializeField] private StatDisplayView durationIntervalDisplayView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LaserDamagePerPulseDisplayController>()
                .WithParameter<IStatDisplayView>(damagePerPulseDisplayView);
            builder.RegisterEntryPoint<LaserPulseIntervalDisplayController>()
                .WithParameter<IStatDisplayView>(pulseIntervalDisplayView);
            builder.RegisterEntryPoint<LaserDurationDisplayController>()
                .WithParameter<IStatDisplayView>(durationIntervalDisplayView);
        }
    }
}