using Core.UI.SegmentedProgressBar;
using VContainer.Unity;

namespace Core.Upgrade.ProgressionDisplay
{
    public sealed class UpgradeProgressionDisplayController : ITickable, IStartable
    {
        private readonly IUpgradeProgressionService _upgradeProgressionService;

        private readonly ISegmentedProgressBarView _view;

        public UpgradeProgressionDisplayController(
            IUpgradeProgressionService upgradeProgressionService,
            ISegmentedProgressBarView view)
        {
            _upgradeProgressionService = upgradeProgressionService;
            _view = view;

            _view.SetQuantizer(new StepCountQuantizer(false));
        }

        //===== Lifecycle =====

        public void Start() => _view.SetQuantizer(new StepCountQuantizer(false));

        public void Tick() => _view.Set(_upgradeProgressionService.ProgressRatio);
    }
}