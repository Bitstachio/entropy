using Core.Foundations.Components;
using Core.StatRegistry.StatKeys;
using Core.Upgrade;
using UnityEngine;
using VContainer;

namespace Features.Player.Attack.Blaster.Upgrade
{
    public sealed class BlasterUpgradeInstaller : Installer
    {
        [SerializeField] private UpgradeDefinition damageUpgrade;
        [SerializeField] private UpgradeDefinition fireRateUpgrade;
        [SerializeField] private UpgradeDefinition projectileSpeedUpgrade;

        public override void Install(IContainerBuilder builder)
        {
            builder.Register<MultiplicativeUpgrade<BlasterStats>>(Lifetime.Scoped)
                .As<IUpgrade>()
                .WithParameter(damageUpgrade)
                .WithParameter(BlasterStats.Damage);
            builder.Register<MultiplicativeUpgrade<BlasterStats>>(Lifetime.Scoped)
                .As<IUpgrade>()
                .WithParameter(fireRateUpgrade)
                .WithParameter(BlasterStats.Interval);
            builder.Register<MultiplicativeUpgrade<BlasterStats>>(Lifetime.Scoped)
                .As<IUpgrade>()
                .WithParameter(projectileSpeedUpgrade)
                .WithParameter(BlasterStats.ProjectileSpeed);
        }
    }
}
