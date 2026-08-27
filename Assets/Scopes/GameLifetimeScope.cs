using System.Linq;
using Core.Foundations.Components;
using Core.Services.RunTime;
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
            //----- Installers -----

            GetComponentsInChildren<Installer>().ToList().ForEach(i => i.Install(builder));

            //----- Run Services -----

            builder.RegisterEntryPoint<RunTimeService>()
                .As<IRunTimeService>();

            //----- Stat Registries -----

            builder.Register<StatRegistry<MovementStats>>(Lifetime.Singleton);
            builder.Register<StatRegistry<ShieldStats>>(Lifetime.Singleton);

            // Weapons
            builder.Register<StatRegistry<BlasterStats>>(Lifetime.Singleton);
            builder.Register<StatRegistry<LaserBeamStats>>(Lifetime.Singleton);
        }
    }
}