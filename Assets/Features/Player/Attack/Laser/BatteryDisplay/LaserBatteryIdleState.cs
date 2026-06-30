using Core.Services.Battery.TimedCharge;

namespace Features.Player.Attack.Laser.BatteryDisplay
{
    public sealed class LaserBatteryIdleState : ITimedChargeBatteryState
    {
        public void Tick(ITimedChargeBatteryService service, float deltaTime)
        {
        }
    }
}