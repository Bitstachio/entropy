using System.Collections.Generic;
using Core.Collectible;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Features.Player.Shield.Collectible.Sfx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Shield.Collectible
{
    public sealed class ShieldCollectibleScope : CollectibleScope
    {
        [Header("Audio Clips")]
        [SerializeField] private AudioClip shieldCollectedClip;
        
        protected override void RegisterFactory(IContainerBuilder builder, ISet<string> collectorTags) =>
            builder.Register<ICollectibleFactory, CollectibleFactory<ShieldCollectibleController>>(Lifetime.Singleton)
                .WithParameter<ISet<string>>(new HashSet<string>(collectorTags));

        protected override void RegisterStats(IContainerBuilder builder)
        {
            builder.RegisterBuildCallback(container =>
            {
                var movementStats = container.Resolve<StatRegistry<ShieldStats>>();
                movementStats.Register(ShieldStats.DropChance, spawnConfig.Probability);
            });
        }

        protected override void RegisterSfx(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<ShieldCollectedSfxController>()
                .WithParameter(shieldCollectedClip);
        }
    }
}