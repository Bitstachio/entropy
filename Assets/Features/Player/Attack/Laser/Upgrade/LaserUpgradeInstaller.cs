using Core.Foundations.Components;
using Features.Player.Upgrade;
using UnityEngine;
using VContainer;

namespace Features.Player.Attack.Laser.Upgrade
{
    public sealed class LaserUpgradeInstaller : Installer
    {
        [SerializeField] private UpgradeDefinition laserDamageUpgrade;
        [SerializeField] private UpgradeDefinition laserPulseIntervalUpgrade;
        [SerializeField] private UpgradeDefinition laserDurationUpgrade;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<LaserDamageUpgrade>(Lifetime.Singleton)
                .As<IUpgrade>()
                .WithParameter(laserDamageUpgrade);
            builder.Register<LaserPulseIntervalUpgrade>(Lifetime.Singleton)
                .As<IUpgrade>()
                .WithParameter(laserPulseIntervalUpgrade);
            builder.Register<LaserDurationUpgrade>(Lifetime.Singleton)
                .As<IUpgrade>()
                .WithParameter(laserDurationUpgrade);
        }
    }
}