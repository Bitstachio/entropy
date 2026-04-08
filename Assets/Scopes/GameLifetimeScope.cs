using Core.Enums;
using Core.Events.Base;
using Core.Events.Channels;
using Features.Hazards.Scripts;
using Features.Progression;
using Features.Shared.Interfaces;
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

        [Header("Settings")]
        [SerializeField] private Rock rockPrefab;
        [SerializeField] private float spawnInterval = 3f;
        [SerializeField] private Transform spawnOrigin;
        [SerializeField] private float spawnXSpeedBound = 2f;

        [Header("Features")]
        [SerializeField] private ProgressionInstaller progressionInstaller;
        
        protected override void Configure(IContainerBuilder builder)
        {
            // Providers
            builder.RegisterComponent(horizontalBoundsProvider).As<IBoundsProvider>();

            // Factories
            builder.Register<RockFactory>(Lifetime.Singleton).WithParameter(rockPrefab);

            // Systems
            builder.RegisterEntryPoint<RockSpawner>()
                .WithParameter("interval", spawnInterval)
                .WithParameter("originPosition", spawnOrigin.position)
                .WithParameter("xSpeedBound", spawnXSpeedBound);

            //===== Event Channels =====

            builder.Register<EventChannel<float>, ScoreUpdatedChannel>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .Keyed(GameEventType.ScoreUpdated);

            builder.Register<EventChannel<float>, RockDestroyed>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .Keyed(GameEventType.RockDestroyed);

            // TODO: Remove section
            //===== Mono Behaviours =====
            
            builder.RegisterComponent(rockPrefab);

            //===== Feature Installers =====
            
            progressionInstaller.Install(builder);
        }
    }
}