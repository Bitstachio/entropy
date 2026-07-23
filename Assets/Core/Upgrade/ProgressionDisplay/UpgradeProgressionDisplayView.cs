using Core.UI.SegmentedProgressBar;
using TMPro;
using UnityEngine;

namespace Core.Upgrade.ProgressionDisplay
{
    public sealed class UpgradeProgressionDisplayView : SegmentedProgressBarView, IUpgradeProgressionDisplayView
    {
        [SerializeField] private TextMeshProUGUI statusDisplay;
        
        public void SetStatus(string status) => statusDisplay.text = status;
    }
}