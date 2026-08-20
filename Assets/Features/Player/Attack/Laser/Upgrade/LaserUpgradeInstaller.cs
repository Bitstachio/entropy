using Core.Foundations.Components;
using Core.StatRegistry.StatKeys;
using Core.Upgrade;
using UnityEngine;
using VContainer;

namespace Features.Player.Attack.Laser.Upgrade
{
    public sealed class LaserUpgradeInstaller : Installer
    {
        [SerializeField] private UpgradeDefinition damageUpgrade;
        [SerializeField] private UpgradeDefinition pulseIntervalUpgrade;
        [SerializeField] private UpgradeDefinition durationUpgrade;

        public override void Install(IContainerBuilder builder)
        {
            builder.Register<MultiplicativeUpgrade<LaserBeamStats>>(Lifetime.Scoped)
                .As<IUpgrade>()
                .WithParameter(damageUpgrade)
                .WithParameter(LaserBeamStats.DamagePerPulse);
            builder.Register<MultiplicativeUpgrade<LaserBeamStats>>(Lifetime.Scoped)
                .As<IUpgrade>()
                .WithParameter(pulseIntervalUpgrade)
                .WithParameter(LaserBeamStats.PulseInterval);
            builder.Register<MultiplicativeUpgrade<LaserBeamStats>>(Lifetime.Scoped)
                .As<IUpgrade>()
                .WithParameter(durationUpgrade)
                .WithParameter(LaserBeamStats.Duration);
        }
    }
}