using System.Collections.Generic;
using Core.Interfaces;
using Core.Providers.Position;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Core.Tag;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Cannon
{
    public sealed class CannonScope : LifetimeScope
    {
        [SerializeField] private CannonballView cannonballView;
        [SerializeField] [Tag] private string[] destroyTags;
        [SerializeField] private TransformPositionProvider transformPositionProvider;

        [SerializeField] private CannonBaselineStats baselineStats;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<StatRegistry<CannonStats>>(Lifetime.Singleton);
            builder.Register<StatRegistry<CannonballStats>>(Lifetime.Singleton);
            builder.RegisterBuildCallback(container =>
            {
                var cannonStats = container.Resolve<StatRegistry<CannonStats>>();
                cannonStats.Register(CannonStats.Interval, baselineStats.FireRate);
                cannonStats.Register(CannonStats.ProjectileSpeed, baselineStats.ProjectileSpeed);

                var cannonballStats = container.Resolve<StatRegistry<CannonballStats>>();
                cannonballStats.Register(CannonballStats.Damage, baselineStats.Damage);
            });

            builder.RegisterComponent(cannonballView).As<ICannonballView>();
            builder.RegisterComponent(transformPositionProvider).As<IPositionProvider>();

            builder.Register<IFactory, CannonballFactory>(Lifetime.Singleton)
                .WithParameter<ISet<string>>(new HashSet<string>(destroyTags));
            builder.RegisterEntryPoint<Cannon>();
        }
    }
}