using System;
using UnityEngine;

namespace Features.Player.Movement
{
    public sealed class MovementView : MonoBehaviour, IMovementView
    {
        private GameControls _controls;
        private Rigidbody2D _rb;

        //===== Lifecycle =====

        private void Awake()
        {
            _controls = new GameControls();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable() => _controls.Enable();

        private void OnDisable() => _controls.Disable();

        private void Update() => OnMovementInputDetected?.Invoke(_controls.Player.Move.ReadValue<float>());

        //===== Interface Implementation =====

        public event Action<float> OnMovementInputDetected;

        public void SetLinearVelocity(float velocity) => _rb.linearVelocity = new Vector2(velocity, 0);
    }
}