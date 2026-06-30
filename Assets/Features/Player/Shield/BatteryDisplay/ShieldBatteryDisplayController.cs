using System;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Services.Battery.InstantCharge;
using Core.UI.SegmentedProgressBar;
using VContainer.Unity;

namespace Features.Player.Shield.BatteryDisplay
{
    public sealed class ShieldBatteryDisplayController : IStartable, IDisposable, ITickable
    {
        private readonly IEventListener<ShieldCollectedEvent> _shieldCollectedListener;

        private readonly IInstantChargeBatteryService _batteryService;
        private readonly ISegmentedProgressBarView _view;

        private IInstantChargeBatteryState _prevState;

        public ShieldBatteryDisplayController(
            IEventListener<ShieldCollectedEvent> shieldCollectedListener,
            IInstantChargeBatteryService batteryService,
            ISegmentedProgressBarView view)
        {
            _shieldCollectedListener = shieldCollectedListener;
            _batteryService = batteryService;
            _view = view;
        }

        //===== Lifecycle =====

        public void Start() => _shieldCollectedListener.OnPublished += HandleShieldCollected;

        public void Dispose() => _shieldCollectedListener.OnPublished -= HandleShieldCollected;

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

        //===== Event Handlers =====

        private void HandleShieldCollected(ShieldCollectedEvent @event) => _batteryService.Charge = 1f;
    }
}