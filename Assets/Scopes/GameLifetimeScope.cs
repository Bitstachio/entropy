using Features.Hazards.Scripts;
using Shared.Interfaces;
using Shared.Providers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public sealed class GameLifetimeScope : LifetimeScope
    {
        [Header("Providers")] [SerializeField] private HorizontalBoundsProvider horizontalBoundsProvider;

        [Header("Settings")] [SerializeField] private Rock rockPrefab;
        [SerializeField] private float spawnInterval = 3f;
        [SerializeField] private Transform spawnOrigin;
        [SerializeField] private float spawnXSpeedBound = 2f;

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
        }
    }
}