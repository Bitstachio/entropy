using System;
using System.Collections.Generic;
using System.Linq;
using Core.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Features.Player.Upgrade
{
    public sealed class UpgradeController : IStartable, IDisposable, ITickable
    {
        private readonly UpgradeControllerConfig _config;
        private readonly IUpgradeRegistry _upgrades;
        private readonly IUpgradeView _view;

        private float _timer;
        private IList<IUpgrade> _currentUpgrades;
        private IReadOnlyList<ICommand> _commands;

        public UpgradeController(UpgradeControllerConfig config, IUpgradeRegistry upgrades, IUpgradeView view)
        {
            _config = config;
            _upgrades = upgrades;
            _view = view;
        }

        //===== Lifecycle =====

        public void Start() => _view.OnUpgradeSelected += HandleUpgradeSelected;

        public void Dispose() => _view.OnUpgradeSelected -= HandleUpgradeSelected;

        public void Tick()
        {
            _timer += Time.deltaTime;
            if (_timer < _config.Interval) return;

            _currentUpgrades = _upgrades.GetRandomSubset(_config.OptionCount);
            _commands = _currentUpgrades.Select(u => new UpgradeCommand(u, 10)).ToList(); // TODO: Remove hard-coded magnitude
            _view.SetOptions(_currentUpgrades.Select(u =>
            {
                var definition = u.Definition;
                return new UpgradeData(definition.Title, definition.Icon, 10f);
            }));
            _view.On();

            _timer = 0;
        }

        //===== Event Handlers =====

        private void HandleUpgradeSelected(int index)
        {
            _commands[index].Execute();
            _view.Off();
        }
    }
}