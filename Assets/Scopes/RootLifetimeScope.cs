using System.Linq;
using Core.Events.Base;
using Core.Foundations.Components;
using Core.Session;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public sealed class RootLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            //----- Event Channels -----

            builder.Register(typeof(EventChannel<>), Lifetime.Singleton)
                .AsImplementedInterfaces();

            //----- Sessions -----

            builder.Register<GameSessionData>(Lifetime.Singleton);
            
            //----- Installers -----
            
            GetComponentsInChildren<Installer>().ToList().ForEach(i => i.Install(builder));
        }
    }
}