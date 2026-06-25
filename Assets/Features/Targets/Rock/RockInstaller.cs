using System.Collections.Generic;
using Core.Audio;
using Core.Foundations.Components;
using Core.Providers.Bounds;
using Features.Targets.Rock.Sfx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Targets.Rock
{
    public sealed class RockInstaller : Installer
    {
        [SerializeField] private List<RockView> rockViews;
        [SerializeField] private HorizontalBoundsProvider horizontalBoundsProvider;
        [SerializeField] private RockDurabilityConfig durabilityConfig;

        [SerializeField] private float spawnInterval = 3f;
        [SerializeField] private Transform spawnOrigin;
        [SerializeField] private float spawnXSpeedBound = 2f;
        
        [Header("Audio Clips")]
        [SerializeField] private AudioClip rockDestroyedClip;
        [SerializeField] private AudioClipConfig rockDestroyedClipConfig;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent(rockViews).As<IReadOnlyList<RockView>>();
            builder.RegisterComponent(durabilityConfig);

            builder.Register<IRockDurabilityProvider, RockDurabilityProvider>(Lifetime.Singleton);
            builder.Register<IRockFactory, RockFactory>(Lifetime.Singleton);
            builder.RegisterEntryPoint<RockSpawner>()
                .WithParameter("interval", spawnInterval)
                .WithParameter("originPosition", spawnOrigin.position)
                .WithParameter("xSpeedBound", spawnXSpeedBound)
                .WithParameter<IBoundsProvider>(horizontalBoundsProvider);
            
            builder.RegisterEntryPoint<RockDestroyedSfxController>()
                .WithParameter(rockDestroyedClip)
                .WithParameter(rockDestroyedClipConfig);
        }
    }
}