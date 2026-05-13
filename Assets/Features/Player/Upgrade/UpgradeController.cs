using System.Linq;
using UnityEngine;
using VContainer.Unity;

namespace Features.Player.Upgrade
{
    public sealed class UpgradeController : ITickable
    {
        private readonly IUpgradeView _view;
        private readonly IUpgradeRegistry _upgrades;
        private readonly UpgradeControllerData _data;

        private float _timer;

        public UpgradeController(IUpgradeView view, IUpgradeRegistry upgrades, UpgradeControllerData data)
        {
            _view = view;
            _upgrades = upgrades;
            _data = data;
        }

        //===== Lifecycle =====

        public void Tick()
        {
            _timer += Time.deltaTime;
            if (_timer < _data.Interval) return;

            _view.SetOptions(_upgrades.GetRandomSubset(_data.OptionCount).Select(u => u.Data));
            _view.On();

            _timer = 0;
        }
    }
}