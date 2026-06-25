using System.Linq;
using Core.Events.Base;
using Core.Foundations.Components;
using Core.Services.TimeScale;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public sealed class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            //----- Global Services -----

            builder.Register<ITimeScaleService, TimeScaleService>(Lifetime.Singleton);
            
            //----- Feature Installers -----

            GetComponentsInChildren<Installer>().ToList().ForEach(i => i.Install(builder));

            //----- Event Channels -----

            builder.Register(typeof(EventChannel<>), Lifetime.Singleton)
                .AsImplementedInterfaces();
            
            //----- Stat Registries -----
            
            builder.Register<StatRegistry<MovementStats>>(Lifetime.Singleton);
            builder.Register<StatRegistry<ShieldStats>>(Lifetime.Singleton);
            
            // Weapons
            builder.Register<StatRegistry<CannonStats>>(Lifetime.Singleton);
            builder.Register<StatRegistry<CannonballStats>>(Lifetime.Singleton);
            builder.Register<StatRegistry<LaserBeamStats>>(Lifetime.Singleton);
        }
    }
}