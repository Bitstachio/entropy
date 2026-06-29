using Core.Services.Battery;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Laser
{
    public sealed class LaserScope : LifetimeScope
    {
        [SerializeField] private LaserBeamView laserBeamView;
        [SerializeField] private LaserInputHandler laserInputHandler;
        [SerializeField] private LaserBatteryConfig laserBatteryConfig;

        [Header("Stats")]
        [SerializeField] private float baselineDamagePerPulse = 1f;
        [SerializeField] private float baselinePulseInterval = 0.5f;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<BatteryService>()
                .As<IBatteryService>()
                .WithParameter<IBatteryState>(new BatteryIdleState())
                .WithParameter(laserBatteryConfig);
            
            builder.RegisterBuildCallback(container =>
            {
                var laserBeamStats = container.Resolve<StatRegistry<LaserBeamStats>>();
                laserBeamStats.Register(LaserBeamStats.DamagePerPulse, baselineDamagePerPulse);
                laserBeamStats.Register(LaserBeamStats.PulseInterval, baselinePulseInterval);
                // TODO: I wonder if this is a code smell
                laserBeamStats.Register(LaserBeamStats.Duration, laserBatteryConfig.DischargeTime);
            });

            builder.Register<ILaserBeamModel, LaserBeamModel>(Lifetime.Singleton);
            builder.RegisterComponent(laserBeamView).As<ILaserBeamView>();
            builder.RegisterComponent(laserInputHandler).As<ILaserInputHandler>();
            builder.RegisterEntryPoint<LaserBeamController>();
        }
    }
}