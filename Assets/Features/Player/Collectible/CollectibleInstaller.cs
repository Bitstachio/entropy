using Core.Events.Channels;
using Core.ExtendedBehaviours;
using Core.Providers.Bounds;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Collectible
{
    public class CollectibleInstaller : Installer
    {
        [SerializeField] private CollectibleView collectibleView;

        [SerializeField] private HorizontalBoundsProvider horizontalBoundsProvider;

        [SerializeField] private float spawnInterval = 3f;
        [SerializeField] private Transform spawnOrigin;
        [SerializeField] private float spawnXSpeedBound = 2f;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent(collectibleView).As<ICollectibleView>();

            // builder.RegisterEntryPoint<ShieldCollectibleController>();

            builder.Register<ICollectibleFactory, CollectibleFactory<ShieldCollectedEvent>>(Lifetime.Singleton);
            builder.RegisterEntryPoint<CollectibleSpawner>()
                .WithParameter("interval", spawnInterval)
                .WithParameter("originPosition", spawnOrigin.position)
                .WithParameter("xSpeedBound", spawnXSpeedBound)
                .WithParameter<IBoundsProvider>(horizontalBoundsProvider);
        }
    }
}