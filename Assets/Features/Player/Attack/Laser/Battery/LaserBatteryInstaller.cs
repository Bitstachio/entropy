using Core.Foundations.Components;
using Core.UI;
using Core.UI.SegmentedProgressBar;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Laser.Battery
{
    public sealed class LaserBatteryInstaller : Installer
    {
        [SerializeField] private SegmentedProgressBarView segmentedProgressBarView;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LaserBatteryController>()
                .WithParameter<IValueDisplay<float>>(segmentedProgressBarView);
        }
    }
}