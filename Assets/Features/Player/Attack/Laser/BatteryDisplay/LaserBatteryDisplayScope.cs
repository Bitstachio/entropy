using Core.UI.SegmentedProgressBar;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Laser.BatteryDisplay
{
    public sealed class LaserBatteryDisplayScope : LifetimeScope
    {
        [SerializeField] private SegmentedProgressBarView segmentedProgressBarView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LaserBatteryDisplayController>()
                .WithParameter<ISegmentedProgressBarView>(segmentedProgressBarView);
        }
    }
}