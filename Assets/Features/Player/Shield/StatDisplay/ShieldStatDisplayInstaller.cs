using Core.Foundations.Components;
using Core.StatDisplay;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Shield.StatDisplay
{
    public sealed class ShieldStatDisplayInstaller : Installer
    {
        [SerializeField] private StatDisplayView shieldDurationDisplayView;
        [SerializeField] private StatDisplayView shieldDropChanceDisplayView;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<ShieldDurationDisplayController>()
                .WithParameter<IStatDisplayView>(shieldDurationDisplayView);
            builder.RegisterEntryPoint<ShieldDropChanceDisplayController>()
                .WithParameter<IStatDisplayView>(shieldDropChanceDisplayView);
        }
    }
}