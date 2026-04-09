using Core.Enums;
using Core.Events.Base;
using Core.Events.Channels;
using Features.Hazards.Rock;
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
        [SerializeField] private ProgressionInstaller progressionInstaller;
        [SerializeField] private RockInstaller rockInstaller;
        
        protected override void Configure(IContainerBuilder builder)
        {
            //===== Event Channels =====

            builder.Register<EventChannel<float>, ScoreUpdatedChannel>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .Keyed(GameEventType.ScoreUpdated);

            builder.Register<EventChannel<float>, RockDestroyed>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .Keyed(GameEventType.RockDestroyed);

            //===== Feature Installers =====
            
            progressionInstaller.Install(builder);
            rockInstaller.Install(builder);
        }
    }
}