using Core.Services.Battery.Rechargeable;
using Core.UI.SegmentedProgressBar;
using VContainer.Unity;

namespace Features.Player.Attack.Laser.BatteryDisplay
{
    public sealed class LaserBatteryDisplayController : ITickable
    {
        private readonly IRechargeableBatteryService rechargeableBatteryService;
        private readonly ISegmentedProgressBarView _view;

        private IRechargeableBatteryState _prevState;

        public LaserBatteryDisplayController(IRechargeableBatteryService rechargeableBatteryService, ISegmentedProgressBarView view)
        {
            this.rechargeableBatteryService = rechargeableBatteryService;
            _view = view;
        }

        //===== Lifecycle =====

        public void Tick()
        {
            var currState = rechargeableBatteryService.State;

            if (_prevState != currState)
            {
                if (currState is IQuantizableState quantizable) _view.SetQuantizer(quantizable.Quantizer);
                _prevState = rechargeableBatteryService.State;
            }

            _view.Set(rechargeableBatteryService.Charge);
        }
    }
}