using System.Linq;
using Core.Foundations.Components;
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