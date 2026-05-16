using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer.Unity;

namespace Features.Player.Upgrade
{
    public sealed class UpgradeController : IStartable, IDisposable, ITickable
    {
        private readonly IUpgradeView _view;
        private readonly IUpgradeRegistry _upgrades;
        private readonly UpgradeControllerData _data;

        private float _timer;
        private IList<IUpgrade> _currentUpgrades;

        public UpgradeController(IUpgradeView view, IUpgradeRegistry upgrades, UpgradeControllerData data)
        {
            _view = view;
            _upgrades = upgrades;
            _data = data;
        }

        //===== Lifecycle =====

        public void Start() => _view.OnUpgradeSelected += HandleUpgradeSelected;

        public void Dispose() => _view.OnUpgradeSelected -= HandleUpgradeSelected;

        public void Tick()
        {
            _timer += Time.deltaTime;
            if (_timer < _data.Interval) return;

            _currentUpgrades = _upgrades.GetRandomSubset(_data.OptionCount);
            _view.SetOptions(_currentUpgrades.Select(u => u.Data));
            _view.On();

            _timer = 0;
        }

        //===== Event Handlers =====

        private void HandleUpgradeSelected(int index)
        {
            Debug.Log($"Applying upgrade {index}");
            _currentUpgrades[index].Apply(10); // TODO: Remove hard-coded magnitude
            _view.Off();
        }
    }
}