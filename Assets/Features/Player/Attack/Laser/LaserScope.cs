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
        [SerializeField] private float baselineDuration = 3f;

        protected override void Configure(IContainerBuilder builder)
        {
            // TODO: Remove hard-coded values and don't resolve by constructor param name
            builder.RegisterEntryPoint<BatteryService>()
                .As<IBatteryService>()
                .WithParameter<IBatteryState>(new BatteryIdleState())
                .WithParameter(laserBatteryConfig);
            
            builder.RegisterBuildCallback(container =>
            {
                var laserBeamStats = container.Resolve<StatRegistry<LaserBeamStats>>();
                laserBeamStats.Register(LaserBeamStats.DamagePerPulse, baselineDamagePerPulse);
                laserBeamStats.Register(LaserBeamStats.PulseInterval, baselinePulseInterval);
                laserBeamStats.Register(LaserBeamStats.Duration, baselineDuration);
            });

            builder.Register<ILaserBeamModel, LaserBeamModel>(Lifetime.Singleton);
            builder.RegisterComponent(laserBeamView).As<ILaserBeamView>();
            builder.RegisterComponent(laserInputHandler).As<ILaserInputHandler>();
            builder.RegisterEntryPoint<LaserBeamController>();
        }
    }
}