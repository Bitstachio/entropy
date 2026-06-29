namespace Core.Services.Battery
{
    public sealed class BatteryChargingState : IBatteryState
    {
        public void Enter(IBatteryService service)
        {
        }

        public void Tick(IBatteryService service, float deltaTime)
        {
            service.Charge += deltaTime / service.ChargeTime;
            
            if (!(service.Charge >= 1)) return;
            
            service.Charge = 1;
            service.TransitionTo(new BatteryIdleState());
        }

        public void Exit(IBatteryService service)
        {
        }
    }
}