using Core.Foundations.Components;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using UnityEngine;
using VContainer;

namespace Features.Player.Attack.Cannon
{
    public sealed class CannonStatsInstaller : Installer
    {
        [Header("Stats")]
        [SerializeField] private float baselineInterval = 1f;
        [SerializeField] private float baselineSpeed = 10f;
        [SerializeField] private float baselineDamage = 1f;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<StatRegistry<CannonStats>>(Lifetime.Singleton);
            builder.Register<StatRegistry<CannonballStats>>(Lifetime.Singleton);
            builder.RegisterBuildCallback(container =>
            {
                var cannonStats = container.Resolve<StatRegistry<CannonStats>>();
                cannonStats.Register(CannonStats.Interval, baselineInterval);
                cannonStats.Register(CannonStats.ProjectileSpeed, baselineSpeed);
                
                var cannonballStats = container.Resolve<StatRegistry<CannonballStats>>();
                cannonballStats.Register(CannonballStats.Damage, baselineDamage);
            });
        }
    }
}