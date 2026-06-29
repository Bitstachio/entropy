using Core.Services.Battery;

namespace Features.Player.Attack.Laser.BatteryDisplay
{
    public sealed class LaserBatteryIdleState : IBatteryState
    {
        public void Tick(IBatteryService service, float deltaTime)
        {
        }
    }
}