using Core.UI;
using Core.UI.SegmentedProgressBar;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Shield.Battery
{
    public sealed class ShieldBatteryScope : LifetimeScope
    {
        [SerializeField] private SegmentedProgressBarView segmentedProgressBarView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<ShieldBatteryController>()
                .WithParameter<IValueDisplay<float>>(segmentedProgressBarView);
        }
    }
}