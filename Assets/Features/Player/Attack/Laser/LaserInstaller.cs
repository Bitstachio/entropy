using Core.Foundations.Components;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Laser
{
    public sealed class LaserInstaller : Installer
    {
        [SerializeField] private LaserBeamView laserBeamView;

        [Header("Stats")]
        [SerializeField] private float baselineDamagePerPulse = 1f;
        [SerializeField] private float baselinePulseInterval = 0.5f;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterBuildCallback(container =>
            {
                var laserBeamStats = container.Resolve<StatRegistry<LaserBeamStats>>();
                laserBeamStats.Register(LaserBeamStats.DamagePerPulse, baselineDamagePerPulse);
                laserBeamStats.Register(LaserBeamStats.PulseInterval, baselinePulseInterval);
            });
            
            builder.Register<ILaserBeamModel, LaserBeamModel>(Lifetime.Singleton);
            builder.RegisterComponent(laserBeamView).As<ILaserBeamView>();
            builder.RegisterEntryPoint<LaserBeamController>();
        }
    }
}