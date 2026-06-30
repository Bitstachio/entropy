using Core.Services.Battery.TimedCharge;
using Core.UI.SegmentedProgressBar;
using VContainer.Unity;

namespace Features.Player.Attack.Laser.BatteryDisplay
{
    public sealed class LaserBatteryDisplayController : ITickable
    {
        private readonly ITimedChargeBatteryService _batteryService;
        private readonly ISegmentedProgressBarView _view;

        private ITimedChargeBatteryState _prevState;

        public LaserBatteryDisplayController(ITimedChargeBatteryService batteryService, ISegmentedProgressBarView view)
        {
            _batteryService = batteryService;
            _view = view;
        }

        //===== Lifecycle =====

        public void Tick()
        {
            var currState = _batteryService.State;

            if (_prevState != currState)
            {
                if (currState is IQuantizableState quantizable) _view.SetQuantizer(quantizable.Quantizer);
                _prevState = _batteryService.State;
            }

            _view.Set(_batteryService.Charge);
        }
    }
}