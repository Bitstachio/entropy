using Core.Foundations.Components;
using Core.StatRegistry.StatKeys;
using Core.Upgrade;
using UnityEngine;
using VContainer;

namespace Features.Player.Attack.Cannon.Upgrade
{
    public sealed class CannonUpgradeInstaller : Installer
    {
        [SerializeField] private UpgradeDefinition damageUpgrade;
        [SerializeField] private UpgradeDefinition fireRateUpgrade;
        [SerializeField] private UpgradeDefinition projectileSpeedUpgrade;

        public override void Install(IContainerBuilder builder)
        {
            builder.Register<MultiplicativeUpgrade<CannonStats>>(Lifetime.Scoped)
                .As<IUpgrade>()
                .WithParameter(damageUpgrade)
                .WithParameter(CannonStats.Damage);
            builder.Register<MultiplicativeUpgrade<CannonStats>>(Lifetime.Scoped)
                .As<IUpgrade>()
                .WithParameter(fireRateUpgrade)
                .WithParameter(CannonStats.Interval);
            builder.Register<MultiplicativeUpgrade<CannonStats>>(Lifetime.Scoped)
                .As<IUpgrade>()
                .WithParameter(projectileSpeedUpgrade)
                .WithParameter(CannonStats.ProjectileSpeed);
        }
    }
}