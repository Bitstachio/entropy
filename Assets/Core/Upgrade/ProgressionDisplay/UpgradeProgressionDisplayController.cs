using System.Collections.Generic;
using System.Linq;
using Core.UI.SegmentedProgressBar;
using VContainer.Unity;

namespace Core.Upgrade.ProgressionDisplay
{
    public sealed class UpgradeProgressionDisplayController : ITickable, IStartable
    {
        private readonly IUpgradeProgressionService _upgradeProgressionService;

        private readonly IUpgradeProgressionDisplayView _view;
        private readonly IReadOnlyList<UpgradeProgressionStatusConfig.Entry> _statusEntries;

        public UpgradeProgressionDisplayController(
            IUpgradeProgressionService upgradeProgressionService,
            IUpgradeProgressionDisplayView view,
            UpgradeProgressionStatusConfig statusConfig)
        {
            _upgradeProgressionService = upgradeProgressionService;
            _view = view;
            _statusEntries = statusConfig.Entries
                .OrderBy(entry => entry.threshold)
                .ToArray();
        }

        //===== Lifecycle =====

        public void Start() => _view.SetQuantizer(new StepCountQuantizer(false));

        public void Tick()
        {
            var ratio = _upgradeProgressionService.ProgressRatio;
            _view.Set(ratio);
            _view.SetStatus(ResolveStatus(ratio));
        }

        //===== Utilities =====

        private string ResolveStatus(float ratio)
        {
            var status = _statusEntries[0].status;

            for (var i = 0; i < _statusEntries.Count; i++)
            {
                if (ratio < _statusEntries[i].threshold) break;
                status = _statusEntries[i].status;
            }

            return status;
        }
    }
}