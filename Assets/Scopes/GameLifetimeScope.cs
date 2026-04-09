using Core.Enums;
using Core.Events.Base;
using Core.Events.Channels;
using Features.Hazards.Rock;
using Features.Orchestration;
using Features.Progression;
using Features.Shared.Providers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public sealed class GameLifetimeScope : LifetimeScope
    {
        [Header("Providers")]
        [SerializeField] private HorizontalBoundsProvider horizontalBoundsProvider;

        [Header("Feature Installers")]
        [SerializeField] private OrchestrationInstaller orchestrationInstaller;
        [SerializeField] private ProgressionInstaller progressionInstaller;
        [SerializeField] private RockInstaller rockInstaller;

        protected override void Configure(IContainerBuilder builder)
        {
            //===== Event Channels =====
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

            //===== Feature Installers =====

            orchestrationInstaller.Install(builder);
            progressionInstaller.Install(builder);
            rockInstaller.Install(builder);
        }
    }
}