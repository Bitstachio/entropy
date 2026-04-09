using System;
using Core.Enums;
using Core.Events.Interfaces;
using Core.Gameplay.Interfaces;
using Features.Hazards.Rock.Interfaces;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Hazards.Rock
{
    public class RockController : IStartable, IDisposable, ISpawnable
    {
        private readonly IEventPublisher<float> _rockDestroyedPublisher;

        private readonly IRockModel _model;
        private readonly IRockView _view;

        public RockController(
            [Key(GameEventType.RockDestroyed)] IEventPublisher<float> rockDestroyedPublisher,
            IRockModel model, IRockView view)
        {
            _rockDestroyedPublisher = rockDestroyedPublisher;
            _model = model;
            _view = view;
        }

        //===== Lifecycle =====

        public void Start()
        {
            _view.SetDurability(_model.Durability);

            _view.OnDamageTaken += HandleDamageTaken;
        }

        public void Dispose()
        {
            _view.OnDamageTaken -= HandleDamageTaken;
        }

        //===== Interface Implementation =====

        public void SetPosition(Vector2 position) => _view.SetPosition(position);

        public void SetVelocity(Vector2 velocity) => _view.SetVelocity(velocity);

        //===== Utilities =====

        private void HandleDamageTaken(float damage)
        {
            _model.TakeDamage(damage);
            _view.SetDurability(_model.Durability);
            if (Mathf.RoundToInt(_model.Durability) > 0) return;
            
            _rockDestroyedPublisher.Publish(_model.MaxDurability);
            _view.Destroy();
        }
    }
}