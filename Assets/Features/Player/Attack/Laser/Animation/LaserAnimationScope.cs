using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Laser.Animation
{
    public sealed class LaserAnimationScope : LifetimeScope
    {
        [SerializeField] private LaserAnimationView laserAnimationView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(laserAnimationView).As<ILaserAnimationView>();
            builder.RegisterEntryPoint<LaserAnimationController>();
        }
    }
}