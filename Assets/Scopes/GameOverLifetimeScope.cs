using System.Linq;
using Core.Events.Base;
using Core.Events.Channels;
using Core.Foundations.Components;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public sealed class GameOverLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            //----- Event Channels -----

            builder.Register<EventChannel<MenuOptionSelected>>(Lifetime.Singleton)
                .AsImplementedInterfaces();

            //----- Feature Installers -----

            GetComponentsInChildren<Installer>().ToList().ForEach(i => i.Install(builder));
        }
    }
}