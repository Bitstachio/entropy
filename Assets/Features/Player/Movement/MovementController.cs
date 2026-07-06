using System;
using Core.Providers.Bounds;
using UnityEngine;
using VContainer.Unity;

namespace Features.Player.Movement
{
    public sealed class MovementController : IStartable, IDisposable, IFixedTickable
    {
        private readonly IMovementModel model;
        private readonly IMovementView view;
        private readonly IBoundsProvider _boundsProvider;

        private float _horizontalInput;

        public MovementController(IMovementModel model, IMovementView view, IBoundsProvider boundsProvider)
        {
            this.model = model;
            this.view = view;
            _boundsProvider = boundsProvider;
        }

        //===== Lifecycle =====

        public void Start() => view.OnMovementInputDetected += HandleMovementInputDetected;

        public void Dispose() => view.OnMovementInputDetected -= HandleMovementInputDetected;

        public void FixedTick()
        {
            view.SetLinearVelocity(Mathf.Abs(_horizontalInput) < 0.01f ? 0 :
                _horizontalInput < 0 && view.XPosition > _boundsProvider.Min ? _horizontalInput * model.TopSpeed :
                _horizontalInput > 0 && view.XPosition < _boundsProvider.Max ? _horizontalInput * model.TopSpeed : 0);
        }

        //===== Event Handlers =====

        private void HandleMovementInputDetected(float value) => _horizontalInput = value;
    }
}