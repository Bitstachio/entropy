using System;
using Features.Hazards.Rock.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Features.Hazards.Rock
{
    public class RockController : IStartable, IDisposable
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

        //===== Utilities =====

        private void HandleDamageTaken(float damage)
        {
            Debug.Log($"Damage taken: {damage}");
        }
    }
}