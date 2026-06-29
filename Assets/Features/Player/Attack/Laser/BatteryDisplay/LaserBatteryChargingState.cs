using Core.Services.Battery;

namespace Features.Player.Attack.Laser.BatteryDisplay
{
    public sealed class LaserBatteryChargingState : IBatteryState
    {
        public void Tick(IBatteryService service, float deltaTime)
        {
            service.Charge += deltaTime / service.ChargeTime;
            
            if (!(service.Charge >= 1)) return;
            
            service.Charge = 1;
            service.TransitionTo(new LaserBatteryIdleState());
        }
    }
}