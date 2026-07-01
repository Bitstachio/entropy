using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Laser.Sfx
{
    public sealed class LaserSfxScope : LifetimeScope
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private LaserSfxConfig laserSfxConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(audioSource).As<AudioSource>();
            builder.RegisterEntryPoint<LaserSfxController>()
                .WithParameter(laserSfxConfig);
        }
    }
}