using UnityEngine;
using VContainer.Unity;

namespace Features.Player.Shield
{
    public sealed class ShieldController : IStartable, ITickable
    {
        private readonly IShieldModel _model;
        private readonly IShieldView _view;
        
        private float _timer;
        
        public ShieldController(IShieldModel model, IShieldView view)
        {
            _model = model;
            _view = view;
        }

        //===== Lifecycle =====
        
        public void Start()
        {
            // TODO: Fix later; this is not actual logic
            Debug.Log("Shield Activated");
            _view.On();
        }

        public void Tick()
        {
            _timer += Time.deltaTime;
            if (_timer < _model.Duration) return;

            // TODO: Fix later; this is not actual logic
            Debug.Log("Shield Deactivated");
            _view.Off();

            _timer = 0;
        }
    }
}