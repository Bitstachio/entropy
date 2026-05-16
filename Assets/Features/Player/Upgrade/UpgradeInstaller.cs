using System.Collections.Generic;
using Core.ExtendedBehaviours;
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

        [Header("Views")]
        [SerializeField] private UpgradeView upgradeView;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(controllerConfig);

            builder.Register<CannonballDamageUpgrade>(Lifetime.Singleton)
                .WithParameter(cannonballDamageUpgrade);
            builder.Register<CannonFireRateUpgrade>(Lifetime.Singleton)
                .WithParameter(cannonFireRateUpgrade);
            builder.Register<CannonProjectileSpeedUpgrade>(Lifetime.Singleton)
                .WithParameter(cannonProjectileSpeedUpgrade);
            builder.Register<IList<IUpgrade>>(container => new List<IUpgrade>
            {
                container.Resolve<CannonballDamageUpgrade>(),
                container.Resolve<CannonFireRateUpgrade>(),
                container.Resolve<CannonProjectileSpeedUpgrade>(),
            }, Lifetime.Singleton);
            builder.Register<IUpgradeRegistry, UpgradeRegistry>(Lifetime.Singleton);

            builder.RegisterComponent(upgradeView).As<IUpgradeView>();
            builder.RegisterEntryPoint<UpgradeController>();
        }
    }
}