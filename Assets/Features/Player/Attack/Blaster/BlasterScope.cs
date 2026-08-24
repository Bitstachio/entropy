using System.Collections.Generic;
using Core.Interfaces;
using Core.Providers.Position;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Core.Tag;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Blaster
{
    public sealed class BlasterScope : LifetimeScope
    {
        [FormerlySerializedAs("cannonballView")]
        [SerializeField] private BoltView boltView;
        [SerializeField] [Tag] private string[] destroyTags;
        [SerializeField] private TransformPositionProvider transformPositionProvider;

        [SerializeField] private BlasterBaselineStats baselineStats;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<StatRegistry<BlasterStats>>(Lifetime.Singleton);
            builder.RegisterBuildCallback(container =>
            {
                var stats = container.Resolve<StatRegistry<BlasterStats>>();
                stats.Register(BlasterStats.Interval, baselineStats.FireRate);
                stats.Register(BlasterStats.ProjectileSpeed, baselineStats.ProjectileSpeed);
                stats.Register(BlasterStats.Damage, baselineStats.Damage);
            });

            builder.RegisterComponent(boltView).As<IBoltView>();
            builder.RegisterComponent(transformPositionProvider).As<IPositionProvider>();

            builder.Register<IFactory, BoltFactory>(Lifetime.Singleton)
                .WithParameter<ISet<string>>(new HashSet<string>(destroyTags));
            builder.RegisterEntryPoint<Blaster>();
        }
    }
}
