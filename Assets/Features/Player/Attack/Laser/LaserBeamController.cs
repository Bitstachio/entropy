using System;
using System.Collections.Generic;
using System.Linq;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Features.Player.Attack.Laser
{
    public sealed class LaserBeamController : IStartable, IDisposable, ITickable
    {
        private readonly IEventPublisher<LaserActivated> _laserActivatedPublisher;

        private readonly ILaserBeamModel _model;
        private readonly ILaserBeamView _view;
        private readonly ILaserInputHandler _input;

        private readonly Dictionary<IDamageable, float> _targetPulseTimers = new();

        private bool _isActive;
        private float _timer;

        public LaserBeamController(
            IEventPublisher<LaserActivated> laserActivatedPublisher,
            ILaserBeamModel model,
            ILaserBeamView view,
            ILaserInputHandler input)
        {
            _laserActivatedPublisher = laserActivatedPublisher;
            _model = model;
            _view = view;
            _input = input;
        }

        //===== Lifecycle =====

        public void Start()
        {
            _view.OnEnterTrigger += HandleEnterTrigger;
            _view.OnExitTrigger += HandleExitTrigger;
            _input.OnActivateInputDetected += HandleActivateInputDetected;
        }

        public void Dispose()
        {
            _view.OnEnterTrigger -= HandleEnterTrigger;
            _view.OnExitTrigger -= HandleExitTrigger;
            _input.OnActivateInputDetected -= HandleActivateInputDetected;
        }

        public void Tick()
        {
            if (!_isActive) return;

            _timer += Time.deltaTime;

            if (_timer <= _model.Duration) ProcessActiveTargets();
            else Deactivate();
        }

        //===== Event Handlers =====

        private void HandleActivateInputDetected()
        {
            // TODO: Add logic to determine if the laser can be activated (i.e., charged)
            Activate();
        }

        private void HandleEnterTrigger(Collider2D other)
        {
            if (other.TryGetComponent<IDamageable>(out var damageable)) _targetPulseTimers[damageable] = 0f;
        }

        private void HandleExitTrigger(Collider2D other)
        {
            if (other.TryGetComponent<IDamageable>(out var damageable)) _targetPulseTimers.Remove(damageable);
        }

        //===== Utilities =====

        private void Activate()
        {
            _isActive = true;
            _timer = 0; // Not redundant; resets duration if the laser is re-activated while already running
            _view.On();
            _laserActivatedPublisher.Publish(new LaserActivated());
        }

        private void Deactivate()
        {
            _isActive = false;
            _timer = 0;
            _targetPulseTimers.Clear();
            _view.Off();
        }

        private void ProcessActiveTargets()
        {
            // Cache stat registry values as the upgrade system can modify values mid-operation
            var damagePerPulse = _model.DamagePerPulse;
            var pulseInterval = _model.PulseInterval;

            foreach (var target in _targetPulseTimers.Keys.ToList())
            {
                if (!IsTargetValid(target))
                {
                    _targetPulseTimers.Remove(target);
                    continue;
                }

                _targetPulseTimers[target] += Time.deltaTime;

                if (_targetPulseTimers[target] < pulseInterval) continue;
                target.Damage(damagePerPulse);
                // Target may have been destroyed/removed after taking damage
                if (_targetPulseTimers.ContainsKey(target)) _targetPulseTimers[target] -= pulseInterval;
            }
        }

        // Destroyed objects remain in the dictionary but are invalid
        private static bool IsTargetValid(IDamageable target) => target is MonoBehaviour mb && mb != null;
    }
}