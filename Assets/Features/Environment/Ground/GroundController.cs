using System;
using System.Collections.Generic;
using Core.Events.Channels;
using Core.Events.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Features.Environment.Ground
{
    public sealed class GroundController : IStartable, IDisposable
    {
        private readonly IEventPublisher<GroundHitEvent> _groundHitPublisher;
        
        private readonly IGroundModel _model;
        private readonly IGroundView _view;

        private readonly ISet<string> _targets;

        public GroundController(
            IEventPublisher<GroundHitEvent> groundHitPublisher,
            IGroundModel model,
            IGroundView view,
            ISet<string> targets)
        {
            _groundHitPublisher = groundHitPublisher;
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
            _groundHitPublisher.Publish(new GroundHitEvent());
            if (_targets.Contains(collision.transform.tag)) ApplyKineticImpulse(collision.rigidbody);
        }

        //===== Utilities =====
        
        private void ApplyKineticImpulse(Rigidbody2D rb)
        {
            var gravity = Mathf.Abs(Physics2D.gravity.y * rb.gravityScale);
            var requiredVelocity = Mathf.Sqrt(2 * gravity * _model.ImpulseMagnitude);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, requiredVelocity);
        }
    }
}