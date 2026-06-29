using Core.Services.Battery;
using Core.UI;
using VContainer.Unity;

namespace Features.Player.Attack.Laser.BatteryDisplay
{
    public sealed class LaserBatteryDisplayController : ITickable
    {
        private readonly IBatteryService _batteryService;
        private readonly IValueDisplay<float> _view;

        public LaserBatteryDisplayController(IBatteryService batteryService, IValueDisplay<float> view)
        {
            _batteryService = batteryService;
            _view = view;
        }

        //===== Lifecycle =====

        public void Tick() => _view.Set(_batteryService.Charge);
    }
}