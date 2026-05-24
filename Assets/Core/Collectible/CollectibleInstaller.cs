using System.Collections.Generic;
using Core.Foundations.Components;
using Core.Providers.Bounds;
using Core.Tag;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Collectible
{
    public abstract class CollectibleInstaller : Installer
    {
        [SerializeField] [Tag] private string[] collectorTags;
        [SerializeField] private CollectibleView collectibleView;

        [SerializeField] private HorizontalBoundsProvider horizontalBoundsProvider;
        [SerializeField] private CollectibleSpawnConfig spawnConfig;
        [SerializeField] private Transform spawnOrigin;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent(collectibleView).As<ICollectibleView>();

            RegisterFactory(builder, new HashSet<string>(collectorTags));
            builder.RegisterEntryPoint<CollectibleSpawner>()
                .WithParameter<IBoundsProvider>(horizontalBoundsProvider)
                .WithParameter(spawnConfig)
                .WithParameter(spawnOrigin.position);
        }

        protected abstract void RegisterFactory(IContainerBuilder builder, ISet<string> collectorTags);
    }
}