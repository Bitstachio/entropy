using System.Collections.Generic;
using Core.Collectible;
using VContainer;

namespace Features.Player.Shield.Collectible
{
    public sealed class ShieldCollectibleInstaller : CollectibleInstaller
    {
        protected override void RegisterFactory(IContainerBuilder builder, ISet<string> collectorTags) =>
            builder.Register<ICollectibleFactory, CollectibleFactory<ShieldCollectibleController>>(Lifetime.Singleton)
                .WithParameter<ISet<string>>(new HashSet<string>(collectorTags));
    }
}