using Core.UI.SegmentedProgressBar;

namespace Core.Upgrade.ProgressionDisplay
{
    public interface IUpgradeProgressionDisplayView : ISegmentedProgressBarView
    {
        void SetStatus(string status);
    }
}