using System.Collections.Generic;
using Core.Providers.Bounds;
using Core.Tag;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Collectible
{
    public abstract class CollectibleScope : LifetimeScope
    {
        [SerializeField] [Tag] private string[] collectorTags;
        [SerializeField] private CollectibleView collectibleView;

        [SerializeField] protected CollectibleSpawnConfig spawnConfig;
        [SerializeField] private HorizontalBoundsProvider horizontalBoundsProvider;
        [SerializeField] private Transform spawnOrigin;

        protected override void Configure(IContainerBuilder builder)
        {
            RegisterStats(builder);
            
            builder.RegisterComponent(collectibleView).As<ICollectibleView>();

            RegisterFactory(builder, new HashSet<string>(collectorTags));
            builder.RegisterEntryPoint<CollectibleSpawner>()
                .WithParameter<IBoundsProvider>(horizontalBoundsProvider)
                .WithParameter(spawnConfig)
                .WithParameter(spawnOrigin.position);
            
            RegisterSfx(builder);
        }

        //===== Utilities =====

        protected abstract void RegisterFactory(IContainerBuilder builder, ISet<string> collectorTags);

        protected virtual void RegisterStats(IContainerBuilder builder)
        {
        }

        protected virtual void RegisterSfx(IContainerBuilder builder)
        {
        }
    }
}