using System;
using VContainer.Unity;
using UnityEngine.InputSystem;

namespace Core.Upgrade
{
    public sealed class UpgradeInputHandler : IUpgradeInputHandler, IStartable, IDisposable
    {
        public event Action<int> OnOptionSelected;

        private readonly GameControls _controls;
        private InputAction[] _optionActions;

        public UpgradeInputHandler(GameControls controls) => _controls = controls;

        //===== Lifecycle =====

        public void Start()
        {
            _controls.Player.Enable();
            _optionActions = new[]
            {
                _controls.Player.SelectOption1,
                _controls.Player.SelectOption2,
                _controls.Player.SelectOption3
            };

            for (var i = 0; i < _optionActions.Length; i++)
            {
                var index = i; // Local copy of `i` is required to prevent closure capture issues inside the lambda
                _optionActions[i].performed += _ => OnOptionSelected?.Invoke(index);
            }
        }
        
        public void Dispose()
        {
            _controls.Disable();
            _controls.Dispose();
        }
    }
}