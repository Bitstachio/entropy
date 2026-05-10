using System;
using Core.Interactions;
using Features.Player.Attack.Cannon.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Features.Player.Attack.Cannon
{
    public sealed class CannonballController : ISpawnable, IStartable, IDisposable
    {
        private readonly ICannonballModel _model;
        private readonly ICannonballView _view;
        
        private readonly string _boundaryTag;
        
        public CannonballController(ICannonballModel model, ICannonballView view, string boundaryTag)
        {
            _model = model;
            _view = view;
            _boundaryTag = boundaryTag;
        }

        //===== Lifecycle =====

        public void Start() => _view.OnHitObject += HandleHitObject;

        public void Dispose() => _view.OnHitObject -= HandleHitObject;
        
        //===== API =====
        
        public void SetPosition(Vector2 position) => _view.SetPosition(position);
        
        public void SetVelocity(Vector2 velocity) => _view.SetVelocity(velocity);

        //===== Event Handlers =====

        private void HandleHitObject(string tag)
        {
            if (tag == _boundaryTag) _view.Destroy();
        }
    }
}