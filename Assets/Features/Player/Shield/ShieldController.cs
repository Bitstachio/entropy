using System;
using Core.Events.Channels;
using Core.Events.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Features.Player.Shield
{
    public sealed class ShieldController : IStartable, IDisposable, ITickable
    {
        private readonly IEventListener<ShieldCollectedEvent> _shieldCollectedListener;

        private readonly IShieldModel _model;
        private readonly IShieldView _view;

        private bool _isViewOn;
        private float _timer;

        public ShieldController(
            IEventListener<ShieldCollectedEvent> shieldCollectedListener,
            IShieldModel model,
            IShieldView view)
        {
            _shieldCollectedListener = shieldCollectedListener;
            _model = model;
            _view = view;
        }

        //===== Lifecycle =====

        public void Start() => _shieldCollectedListener.OnPublished += HandleShieldCollected;

        public void Dispose() => _shieldCollectedListener.OnPublished -= HandleShieldCollected;

        public void Tick()
        {
            _timer += Time.deltaTime;
            if (_timer < _model.Duration || !_isViewOn) return;

            DeactivateShield();

            _timer = 0;
        }

        //===== Event Handlers =====

        private void HandleShieldCollected(ShieldCollectedEvent @event)
        {
            ActivateShield();
            _timer = 0;
        }

        //===== Utilities =====

        private void ActivateShield()
        {
            _view.On();
            _isViewOn = true;
        }

        private void DeactivateShield()
        {
            _view.Off();
            _isViewOn = false;
        }
    }
}