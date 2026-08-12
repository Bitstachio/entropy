using System.Collections.Generic;
using Core.Interfaces;
using Core.Providers.Position;
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

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(cannonballView).As<ICannonballView>();
            builder.RegisterComponent(transformPositionProvider).As<IPositionProvider>();

            builder.Register<IFactory, CannonballFactory>(Lifetime.Singleton)
                .WithParameter<ISet<string>>(new HashSet<string>(destroyTags));
            builder.RegisterEntryPoint<Cannon>();
        }
    }
}