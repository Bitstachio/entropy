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
        
        private readonly IReadOnlyDictionary<float, string> _statusLogs = new Dictionary<float, string>
        {
            { 0.00f, "Connecting to Gateway..." },
            { 0.20f, "Downloading Payload..." },
            { 0.40f, "Integrating Modules..." },
            { 0.90f, "Booting Dispatcher..." },
            { 1f, "Upgrade Ready" }
        };

        public UpgradeProgressionDisplayController(
            IUpgradeProgressionService upgradeProgressionService,
            IUpgradeProgressionDisplayView view)
        {
            _upgradeProgressionService = upgradeProgressionService;
            _view = view;

            _view.SetQuantizer(new StepCountQuantizer(false));
        }

        //===== Lifecycle =====

        public void Start() => _view.SetQuantizer(new StepCountQuantizer(false));

        public void Tick()
        {
            _view.Set(_upgradeProgressionService.ProgressRatio);
            _view.SetStatus(_statusLogs[
                _statusLogs.Keys.Where(threshold => _upgradeProgressionService.ProgressRatio >= threshold)
                    .DefaultIfEmpty(0f).Max()]);
        }
    }
}