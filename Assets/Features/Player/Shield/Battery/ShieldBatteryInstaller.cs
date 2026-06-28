using Core.Foundations.Components;
using Core.UI;
using Core.UI.SegmentedProgressBar;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Shield.Battery
{
    public sealed class ShieldBatteryInstaller : Installer
    {
        [SerializeField] private SegmentedProgressBarView segmentedProgressBarView;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent(segmentedProgressBarView).As<IValueDisplay<float>>();
            builder.RegisterEntryPoint<ShieldBatteryController>();
        }
    }
}