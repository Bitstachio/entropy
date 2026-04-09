using System;
using Core.Gameplay.Interfaces;
using Features.Hazards.Rock.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Features.Hazards.Rock
{
    public class RockController : IStartable, IDisposable, ISpawnable
    {
        private readonly IRockModel _model;
        private readonly IRockView _view;

        public RockController(IRockModel model, IRockView view)
        {
            _model = model;
            _view = view;
        }

        //===== Lifecycle =====

        public void Start()
        {
            // TODO: Remove
            Debug.Log("Listener registered");
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
            Debug.Log($"Damage taken: {damage}");
        }
    }
}