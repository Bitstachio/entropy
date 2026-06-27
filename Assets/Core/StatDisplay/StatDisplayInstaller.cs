using Core.Foundations.Components;
using Features.StatDisplay;
using Features.StatDisplay.Controllers.Shield;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.StatDisplay
{
    public class StatDisplayInstaller : Installer
    {
        [Header("Shield Stats")]
        [SerializeField] private StatDisplayView shieldDurationDisplayView;
        [SerializeField] private StatDisplayView shieldDropChanceDisplayView;

        public override void Install(IContainerBuilder builder)
        {
            // Weapon stats

            // Shield stats
            builder.RegisterEntryPoint<ShieldDurationDisplayController>()
                .WithParameter<IStatDisplayView>(shieldDurationDisplayView);
            builder.RegisterEntryPoint<ShieldDropChanceDisplayController>()
                .WithParameter<IStatDisplayView>(shieldDropChanceDisplayView);
        }
    }
}