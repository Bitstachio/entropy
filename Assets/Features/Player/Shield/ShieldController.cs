using System;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Services.Battery.InstantCharge;
using Features.Player.Shield.BatteryDisplay;
using UnityEngine;
using VContainer.Unity;

namespace Features.Player.Shield
{
    public sealed class ShieldController : IStartable, IDisposable, ITickable
    {
        private readonly IEventListener<ShieldCollectedEvent> _shieldCollectedListener;

        private readonly IInstantChargeBatteryService _batteryService;
        private readonly IShieldModel _model;
        private readonly IShieldView _view;

        private bool _isViewOn;
        private float _timer;

        public ShieldController(
            IEventListener<ShieldCollectedEvent> shieldCollectedListener,
            IInstantChargeBatteryService batteryService,
            IShieldModel model,
            IShieldView view)
        {
            _shieldCollectedListener = shieldCollectedListener;
            _batteryService = batteryService;
            _model = model;
            _view = view;
        }

        //===== Lifecycle =====

        public void Start()
        {
            _shieldCollectedListener.OnPublished += HandleShieldCollected;

            _batteryService.TransitionTo(new ShieldBatteryIdleState());
        }

        public void Dispose() => _shieldCollectedListener.OnPublished -= HandleShieldCollected;

        public void Tick()
        {
            _timer += Time.deltaTime;
            if (_timer < _model.Duration || !_isViewOn) return;

            Deactivate();

            _timer = 0;
        }

        //===== Event Handlers =====

        private void HandleShieldCollected(ShieldCollectedEvent @event)
        {
            Activate();
            _timer = 0;
        }

        //===== Utilities =====

        private void Activate()
        {
            _batteryService.TransitionTo(new ShieldBatteryDischargingState());
            _view.On();
            _isViewOn = true;
        }

        private void Deactivate()
        {
            _batteryService.TransitionTo(new ShieldBatteryIdleState());
            _view.Off();
            _isViewOn = false;
        }
    }
}