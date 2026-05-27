using System.Collections.Generic;
using Core.Foundations.Components;
using Features.Player.Upgrade.Sfx;
using Features.Player.Upgrade.Strategies;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Upgrade
{
    public sealed class UpgradeInstaller : Installer
    {
        [Header("Data")]
        [SerializeField] private UpgradeControllerConfig controllerConfig;
        [SerializeField] private UpgradeDefinition cannonballDamageUpgrade;
        [SerializeField] private UpgradeDefinition cannonFireRateUpgrade;
        [SerializeField] private UpgradeDefinition cannonProjectileSpeedUpgrade;
        [SerializeField] private UpgradeDefinition shieldDurationUpgrade;
        [SerializeField] private UpgradeDefinition shieldDropChanceUpgrade;

        [Header("Views")]
        [SerializeField] private UpgradeView upgradeView;
        
        [Header("Audio Clips")]
        [SerializeField] private AudioClip upgradePanelOpenedClip;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(controllerConfig);

            builder.Register<CannonballDamageUpgrade>(Lifetime.Singleton)
                .WithParameter(cannonballDamageUpgrade);
            builder.Register<CannonFireRateUpgrade>(Lifetime.Singleton)
                .WithParameter(cannonFireRateUpgrade);
            builder.Register<CannonProjectileSpeedUpgrade>(Lifetime.Singleton)
                .WithParameter(cannonProjectileSpeedUpgrade);
            builder.Register<ShieldDurationUpgrade>(Lifetime.Singleton)
                .WithParameter(shieldDurationUpgrade);
            builder.Register<ShieldDropChanceUpgrade>(Lifetime.Singleton)
                .WithParameter(shieldDropChanceUpgrade);
            builder.Register<IList<IUpgrade>>(container => new List<IUpgrade>
            {
                container.Resolve<CannonballDamageUpgrade>(),
                container.Resolve<CannonFireRateUpgrade>(),
                container.Resolve<CannonProjectileSpeedUpgrade>(),
                container.Resolve<ShieldDurationUpgrade>(),
                container.Resolve<ShieldDropChanceUpgrade>(),
            }, Lifetime.Singleton);
            builder.Register<IUpgradeRegistry, UpgradeRegistry>(Lifetime.Singleton);

            builder.RegisterComponent(upgradeView).As<IUpgradeView>();
            builder.RegisterEntryPoint<UpgradeController>();
            
            builder.RegisterEntryPoint<UpgradePanelOpenedSfxController>()
                .WithParameter(upgradePanelOpenedClip);
        }
    }
}