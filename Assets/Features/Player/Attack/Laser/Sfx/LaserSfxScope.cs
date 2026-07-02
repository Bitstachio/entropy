using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Laser.Sfx
{
    public sealed class LaserSfxScope : LifetimeScope
    {
        [SerializeField] private LaserSfxConfig laserSfxConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LaserSfxController>()
                .WithParameter(laserSfxConfig);
        }
    }
}