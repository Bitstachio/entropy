using System.Linq;
using Core.Events.Base;
using Core.ExtendedBehaviours;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public sealed class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            //----- Feature Installers -----

            GetComponentsInChildren<Installer>().ToList().ForEach(i => i.Install(builder));

            //----- Event Channels -----

            builder.Register(typeof(EventChannel<>), Lifetime.Singleton)
                .AsImplementedInterfaces();
        }
    }
}