using Core.Foundations.Components;
using Features.Player.Upgrade;
using UnityEngine;
using VContainer;

namespace Features.Player.Shield.Upgrade
{
    public sealed class ShieldUpgradeInstaller : Installer
    {
        [SerializeField] private UpgradeDefinition shieldDurationUpgrade;
        [SerializeField] private UpgradeDefinition shieldDropChanceUpgrade;

        public override void Install(IContainerBuilder builder)
        {
            builder.Register<ShieldDurationUpgrade>(Lifetime.Singleton)
                .As<IUpgrade>()
                .WithParameter(shieldDurationUpgrade);
            builder.Register<ShieldDropChanceUpgrade>(Lifetime.Singleton)
                .As<IUpgrade>()
                .WithParameter(shieldDropChanceUpgrade);
        }
    }
}