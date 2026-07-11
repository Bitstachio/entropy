using Core.Foundations.Components;
using Features.Player.Upgrade;
using UnityEngine;
using VContainer;

namespace Features.Player.Attack.Cannon.Upgrade
{
    public sealed class CannonUpgradeInstaller : Installer
    {
        [SerializeField] private UpgradeDefinition cannonballDamageUpgrade;
        [SerializeField] private UpgradeDefinition cannonFireRateUpgrade;
        [SerializeField] private UpgradeDefinition cannonProjectileSpeedUpgrade;

        public override void Install(IContainerBuilder builder)
        {
            builder.Register<CannonballDamageUpgrade>(Lifetime.Singleton)
                .As<IUpgrade>()
                .WithParameter(cannonballDamageUpgrade);
            builder.Register<CannonFireRateUpgrade>(Lifetime.Singleton)
                .As<IUpgrade>()
                .WithParameter(cannonFireRateUpgrade);
            builder.Register<CannonProjectileSpeedUpgrade>(Lifetime.Singleton)
                .As<IUpgrade>()
                .WithParameter(cannonProjectileSpeedUpgrade);
        }
    }
}