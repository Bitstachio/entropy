using Core.Foundations.Components;
using Core.StatDisplay;
using Features.StatDisplay;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Laser.StatDisplay
{
    public sealed class LaserStatDisplayInstaller : Installer
    {
        [SerializeField] private StatDisplayView damagePerPulseDisplayView;
        [SerializeField] private StatDisplayView pulseIntervalDisplayView;
        [SerializeField] private StatDisplayView durationIntervalDisplayView;
        
        public override void Install(IContainerBuilder builder)
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