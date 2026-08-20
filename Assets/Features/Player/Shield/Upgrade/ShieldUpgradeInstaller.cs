using Core.Foundations.Components;
using Core.StatRegistry.StatKeys;
using Core.Upgrade;
using UnityEngine;
using VContainer;

namespace Features.Player.Shield.Upgrade
{
    public sealed class ShieldUpgradeInstaller : Installer
    {
        [SerializeField] private UpgradeDefinition durationUpgrade;
        [SerializeField] private UpgradeDefinition dropChanceUpgrade;

        public override void Install(IContainerBuilder builder)
        {
            builder.Register<MultiplicativeUpgrade<ShieldStats>>(Lifetime.Scoped)
                .As<IUpgrade>()
                .WithParameter(durationUpgrade)
                .WithParameter(ShieldStats.Duration);
            builder.Register<MultiplicativeUpgrade<ShieldStats>>(Lifetime.Scoped)
                .As<IUpgrade>()
                .WithParameter(dropChanceUpgrade)
                .WithParameter(ShieldStats.DropChance);
        }
    }
}