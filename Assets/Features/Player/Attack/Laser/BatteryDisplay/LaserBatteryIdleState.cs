using Core.Services.Battery.Rechargeable;

namespace Features.Player.Attack.Laser.BatteryDisplay
{
    public sealed class LaserBatteryIdleState : IRechargeableBatteryState
    {
        public void Tick(IRechargeableBatteryService service, float deltaTime)
        {
        }
    }
}