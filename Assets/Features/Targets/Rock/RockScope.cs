using System.Collections.Generic;
using Core.Providers.Bounds;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Targets.Rock
{
    public sealed class RockScope : LifetimeScope
    {
        [SerializeField] private List<RockView> rockViews;
        [SerializeField] private HorizontalBoundsProvider horizontalBoundsProvider;
        [SerializeField] private RockDurabilityConfig durabilityConfig;

        [SerializeField] private Transform spawnOrigin;
        [SerializeField] private float spawnXSpeedBound = 2f;
        [SerializeField] private float spawnInitialDelay = 2f;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(rockViews).As<IReadOnlyList<RockView>>();
            builder.RegisterComponent(durabilityConfig);

            builder.Register<IRockDurabilityProvider, RockDurabilityProvider>(Lifetime.Singleton);
            builder.Register<IRockFactory, RockFactory>(Lifetime.Singleton);
            builder.RegisterEntryPoint<RockSpawner>()
                .WithParameter("config", durabilityConfig)
                .WithParameter("originPosition", spawnOrigin.position)
                .WithParameter("xSpeedBound", spawnXSpeedBound)
                .WithParameter("initialDelay", spawnInitialDelay)
                .WithParameter<IBoundsProvider>(horizontalBoundsProvider);
        }
    }
}