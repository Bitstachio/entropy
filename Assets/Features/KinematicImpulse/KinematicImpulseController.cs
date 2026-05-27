using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace Features.KinematicImpulse
{
    public sealed class KinematicImpulseController : IStartable, IDisposable
    {
        private readonly IKinematicImpulseModel _model;
        private readonly IKinematicImpulseView _view;

        private readonly ISet<string> _targets;

        public KinematicImpulseController(
            IKinematicImpulseModel model,
            IKinematicImpulseView view,
            ISet<string> targets)
        {
            _model = model;
            _view = view;
            _targets = targets;
        }

        //===== Lifecycle =====
        
        public void Start() => _view.OnCollided += HandleCollision;

        public void Dispose() => _view.OnCollided += HandleCollision;

        //===== Event Handlers =====

        private void HandleCollision(Collision2D collision)
        {
            if (_targets.Contains(collision.transform.tag)) ApplyKineticImpulse(collision.rigidbody);
        }

        //===== Utilities =====
        
        private void ApplyKineticImpulse(Rigidbody2D rb)
        {
            var gravity = Mathf.Abs(Physics2D.gravity.y * rb.gravityScale);
            var requiredVelocity = Mathf.Sqrt(2 * gravity * _model.Magnitude);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, requiredVelocity);
        }
    }
}