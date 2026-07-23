using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Upgrade.ProgressionDisplay
{
    public sealed class UpgradeProgressionDisplayScope : LifetimeScope
    {
        [SerializeField] private UpgradeProgressionDisplayView segmentedProgressBarView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<UpgradeProgressionDisplayController>()
                .WithParameter<IUpgradeProgressionDisplayView>(segmentedProgressBarView);
        }
    }
}