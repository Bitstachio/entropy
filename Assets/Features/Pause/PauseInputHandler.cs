using System;
using UnityEngine;

namespace Features.Pause
{
    public sealed class PauseInputHandler : MonoBehaviour, IPauseInputHandler
    {
        public event Action OnPauseToggleInputDetected;

        private GameControls _controls;

        //===== Lifecycle =====

        private void Awake() => _controls = new GameControls();

        private void OnEnable() => _controls.Enable();

        private void OnDisable() => _controls.Disable();

        private void Update()
        {
            if (_controls.Player.TogglePause.WasPressedThisFrame()) OnPauseToggleInputDetected?.Invoke();
        }
    }
}