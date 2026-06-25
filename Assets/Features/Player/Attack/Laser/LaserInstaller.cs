using Core.Foundations.Components;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Laser
{
    public sealed class LaserInstaller : Installer
    {
        [SerializeField] private LaserBeamView laserBeamView;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<ILaserBeamModel, LaserBeamModel>(Lifetime.Singleton);
            builder.RegisterComponent(laserBeamView).As<ILaserBeamView>();
            builder.RegisterEntryPoint<LaserBeamController>();
        }
    }
}