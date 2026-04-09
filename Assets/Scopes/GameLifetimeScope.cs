using System;
using System.Collections.Generic;
using System.Linq;
using Core.Enums;
using Core.Events.Channels;
using Core.ExtendedBehaviours;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public sealed class GameLifetimeScope : LifetimeScope
    {
        private static readonly Dictionary<Type, GameEventType> EventChannelToType = new()
        {
            { typeof(GameOver), GameEventType.GameOver },
            { typeof(ScoreUpdatedChannel), GameEventType.ScoreUpdated },
            { typeof(RockDestroyed), GameEventType.RockDestroyed },
            { typeof(RockHitObject), GameEventType.RockHitObject },
        };

        protected override void Configure(IContainerBuilder builder)
        {
            //----- Feature Installers -----

            GetComponentsInChildren<Installer>().ToList().ForEach(i => i.Install(builder));

            //----- Event Channels -----
            // While explicit registration `.As<T>` is generally preferred for clarity,
            // `.AsImplementedInterfaces()` is used here for brevity as all event channels
            // strictly implement the same `IEventPublisher` and `IEventListener` pair.

            EventChannelToType.ToList().ForEach(pair =>
                builder.Register(pair.Key, Lifetime.Singleton)
                    .AsImplementedInterfaces()
                    .Keyed(pair.Value));
        }
    }
}