using System.Collections.Generic;
using Core.ExtendedBehaviours;
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

        [SerializeField] private float spawnInterval = 3f;
        [SerializeField] private Transform spawnOrigin;
        [SerializeField] private float spawnXSpeedBound = 2f;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent(collectibleView).As<ICollectibleView>();

            RegisterFactory(builder, new HashSet<string>(collectorTags));
            builder.RegisterEntryPoint<CollectibleSpawner>()
                .WithParameter("interval", spawnInterval)
                .WithParameter("originPosition", spawnOrigin.position)
                .WithParameter("xSpeedBound", spawnXSpeedBound)
                .WithParameter<IBoundsProvider>(horizontalBoundsProvider);
        }

        protected abstract void RegisterFactory(IContainerBuilder builder, ISet<string> collectorTags);
    }
}