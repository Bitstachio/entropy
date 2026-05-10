using System;
using Features.Player.Movement.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Features.Player.Movement
{
    public class MovementController : IStartable, IDisposable, IFixedTickable
    {
        private readonly IMovementModel model;
        private readonly IMovementView view;

        private float _horizontalInput;

        public MovementController(IMovementModel model, IMovementView view)
        {
            this.model = model;
            this.view = view;
        }

        //===== Lifecycle =====

        public void Start() => view.OnMovementInputDetected += HandleMovementInputDetected;

        public void Dispose() => view.OnMovementInputDetected -= HandleMovementInputDetected;

        public void FixedTick() =>
            view.SetLinearVelocity(Mathf.Abs(_horizontalInput) < 0.01f ? 0 : _horizontalInput * model.TopSpeed);

        //===== Event Handlers =====

        private void HandleMovementInputDetected(float value) => _horizontalInput = value;
    }
}