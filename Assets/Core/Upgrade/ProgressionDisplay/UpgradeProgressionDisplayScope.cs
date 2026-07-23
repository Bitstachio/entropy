using Core.UI.SegmentedProgressBar;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Upgrade.ProgressionDisplay
{
    public sealed class UpgradeProgressionDisplayScope : LifetimeScope
    {
        [SerializeField] private SegmentedProgressBarView segmentedProgressBarView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<UpgradeProgressionDisplayController>()
                .WithParameter<ISegmentedProgressBarView>(segmentedProgressBarView);
        }
    }
}