using System;
using UnityEngine;

namespace Features.Player.Attack.Laser
{
    public sealed class LaserInputHandler : MonoBehaviour, ILaserInputHandler
    {
        public event Action OnActivateInputDetected;

        private GameControls _controls;

        //===== Lifecycle =====

        private void Awake() => _controls = new GameControls();

        private void OnEnable() => _controls.Enable();

        private void OnDisable() => _controls.Disable();

        private void Update()
        {
            if (_controls.Player.ActivateLaser.WasPressedThisFrame()) OnActivateInputDetected?.Invoke();
        }
    }
}