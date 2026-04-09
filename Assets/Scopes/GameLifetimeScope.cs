using System.Linq;
using Core.Enums;
using Core.Events.Base;
using Core.Events.Channels;
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
            // While explicit registration `.As<T>` is generally preferred for clarity,
            // `.AsImplementedInterfaces()` is used here for brevity as all event channels
            // strictly implement the same `IEventPublisher` and `IEventListener` pair.

            builder.Register<EventChannel, GameOver>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .Keyed(GameEventType.GameOver);

            builder.Register<EventChannel<float>, ScoreUpdatedChannel>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .Keyed(GameEventType.ScoreUpdated);

            builder.Register<EventChannel<float>, RockDestroyed>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .Keyed(GameEventType.RockDestroyed);

            builder.Register<EventChannel<string>, RockHitObject>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .Keyed(GameEventType.RockHitObject);
        }
    }
}