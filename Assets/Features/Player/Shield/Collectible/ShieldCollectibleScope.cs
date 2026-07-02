using System.Collections.Generic;
using Core.Collectible;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using UnityEngine;
using VContainer;

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
            // TODO: I don't think I want to register SFX here
            // builder.RegisterEntryPoint<ShieldActivatedSfxController>()
            //     .WithParameter(shieldCollectedClip);
        }
    }
}