namespace Core.Services.Battery
{
    public sealed class BatteryIdleState : IBatteryState
    {
        public void Enter(IBatteryService service)
        {
        }

        public void Tick(IBatteryService service, float deltaTime)
        {
        }

        public void Exit(IBatteryService service)
        {
        }
    }
}