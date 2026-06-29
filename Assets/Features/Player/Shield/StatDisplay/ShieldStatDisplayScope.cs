using Core.StatDisplay;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Shield.StatDisplay
{
    public sealed class ShieldStatDisplayScope : LifetimeScope
    {
        [SerializeField] private StatDisplayView shieldDurationDisplayView;
        [SerializeField] private StatDisplayView shieldDropChanceDisplayView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<ShieldDurationDisplayController>()
                .WithParameter<IStatDisplayView>(shieldDurationDisplayView);
            builder.RegisterEntryPoint<ShieldDropChanceDisplayController>()
                .WithParameter<IStatDisplayView>(shieldDropChanceDisplayView);
        }
    }
}