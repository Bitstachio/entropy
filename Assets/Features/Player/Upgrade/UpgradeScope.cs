using Core.Foundations.Components;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Upgrade
{
    public sealed class UpgradeScope : LifetimeScope
    {
        [SerializeField] private UpgradeView upgradeView;
        [SerializeField] private UpgradeControllerConfig controllerConfig;

        /*
         * Using installers instead of child scopes because child registrations
         * aren't visible to a parent, and UpgradeRegistry (registered below)
         * needs to resolve every upgrade via IEnumerable<IUpgrade> from this
         * one container.
         * Using serialized references instead of GetComponentsInChildren to
         * avoid a scene traversal at container build time for a fixed, known
         * set of installers.
         */
        [SerializeField] private Installer cannonUpgradeInstaller;
        [SerializeField] private Installer laserUpgradeInstaller;
        [SerializeField] private Installer shieldUpgradeInstaller;

        protected override void Configure(IContainerBuilder builder)
        {
            cannonUpgradeInstaller.Install(builder);
            laserUpgradeInstaller.Install(builder);
            shieldUpgradeInstaller.Install(builder);

            builder.RegisterInstance(controllerConfig);
            builder.Register<IUpgradeRegistry, UpgradeRegistry>(Lifetime.Singleton);
            builder.RegisterComponent(upgradeView).As<IUpgradeView>();
            builder.RegisterEntryPoint<UpgradeController>();
        }
    }
}