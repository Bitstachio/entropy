using Core.UI.SegmentedProgressBar;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Shield.BatteryDisplay
{
    public sealed class ShieldBatteryDisplayScope : LifetimeScope
    {
        [SerializeField] private SegmentedProgressBarView segmentedProgressBarView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<ShieldBatteryDisplayController>()
                .WithParameter<ISegmentedProgressBarView>(segmentedProgressBarView);
        }
    }
}