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
        private readonly IUpgradeRegistry _registry;
        private readonly IUpgradeView _view;

        private float _timer;
        private IReadOnlyList<ICommand> _commands;

        public UpgradeController(UpgradeControllerConfig config, IUpgradeRegistry registry, IUpgradeView view)
        {
            _config = config;
            _registry = registry;
            _view = view;
        }

        //===== Lifecycle =====

        public void Start() => _view.OnUpgradeSelected += HandleUpgradeSelected;

        public void Dispose() => _view.OnUpgradeSelected -= HandleUpgradeSelected;

        public void Tick()
        {
            _timer += Time.deltaTime;
            if (_timer < _config.Interval) return;

            var options = UpgradeUtils.PrepOptions(_registry.Upgrades, _config.OptionCount);
            _commands = options.Select(o => o.Command).ToList();
            _view.SetOptions(options.Select(o => new UpgradeData(o.Data.Title, o.Data.Icon, o.Data.Magnitude)));
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