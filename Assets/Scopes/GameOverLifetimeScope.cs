using Core.Events.Base;
using Core.Events.Channels;
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
        }
    }
}