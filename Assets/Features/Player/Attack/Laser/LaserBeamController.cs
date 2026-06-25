using System;
using System.Collections.Generic;
using System.Linq;
using Core.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Features.Player.Attack.Laser
{
    public sealed class LaserBeamController : IStartable, IDisposable, ITickable
    {
        private readonly ILaserBeamModel _model;
        private readonly ILaserBeamView _view;

        private readonly Dictionary<IDamageable, float> _activeTargets = new();

        public LaserBeamController(ILaserBeamModel model, ILaserBeamView view)
        {
            _model = model;
            _view = view;
        }

        //===== Lifecycle =====

        public void Start()
        {
            _view.OnEnterTrigger += HandleEnterTrigger;
            _view.OnExitTrigger += HandleExitTrigger;
        }

        public void Dispose()
        {
            _view.OnEnterTrigger -= HandleEnterTrigger;
            _view.OnExitTrigger -= HandleExitTrigger;
        }

        public void Tick()
        {
            // Cache stat registry values as the upgrade system can modify values mid-operation
            var damagePerPulse = _model.DamagePerPulse;
            var pulseInterval = _model.PulseInterval;

            foreach (var target in _activeTargets.Keys.ToList())
            {
                if (!IsTargetValid(target))
                {
                    _activeTargets.Remove(target);
                    continue;
                }

                _activeTargets[target] += Time.deltaTime;

                if (_activeTargets[target] < pulseInterval) continue;
                target.Damage(damagePerPulse);
                // Target may have been destroyed/removed after taking damage
                if (_activeTargets.ContainsKey(target)) _activeTargets[target] -= pulseInterval;
            }
        }

        //===== Event Handlers =====

        private void HandleEnterTrigger(Collider2D other)
        {
            if (other.TryGetComponent<IDamageable>(out var damageable)) _activeTargets[damageable] = 0f;
        }

        private void HandleExitTrigger(Collider2D other)
        {
            if (other.TryGetComponent<IDamageable>(out var damageable)) _activeTargets.Remove(damageable);
        }

        //===== Utilities =====

        // Destroyed objects remain in the dictionary but are invalid
        private static bool IsTargetValid(IDamageable target) => target is MonoBehaviour mb && mb != null;
    }
}