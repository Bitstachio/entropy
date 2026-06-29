using Core.Services.Battery;
using Core.UI.SegmentedProgressBar;
using VContainer.Unity;

namespace Features.Player.Attack.Laser.BatteryDisplay
{
    public sealed class LaserBatteryDisplayController : ITickable
    {
        private readonly IBatteryService _batteryService;
        private readonly ISegmentedProgressBarView _view;

        private IBatteryState _prevState;

        public LaserBatteryDisplayController(IBatteryService batteryService, ISegmentedProgressBarView view)
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
                switch (currState)
                {
                    case LaserBatteryChargingState:
                        _view.SetQuantizer(new LaserBatteryChargingQuantizer());
                        break;
                    case LaserBatteryDischargingState:
                        _view.SetQuantizer(new LaserBatteryDischargingQuantizer());
                        break;
                }

                _prevState = _batteryService.State;
            }

            _view.Set(_batteryService.Charge);
        }
    }
}