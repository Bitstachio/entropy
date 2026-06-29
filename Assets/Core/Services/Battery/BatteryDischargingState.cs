namespace Core.Services.Battery
{
    public sealed class BatteryDischargingState : IBatteryState
    {
        public void Enter(IBatteryService service)
        {
        }

        public void Tick(IBatteryService service, float deltaTime)
        {
            service.Charge -= deltaTime / service.ChargeTime;
            
            if (!(service.Charge <= 0)) return;
            
            service.Charge = 0;
            service.TransitionTo(new BatteryIdleState());
        }

        public void Exit(IBatteryService service)
        {
        }
    }
}