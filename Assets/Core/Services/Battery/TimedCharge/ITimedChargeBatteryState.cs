namespace Core.Services.Battery.TimedCharge
{
    public interface ITimedChargeBatteryState
    {
        void Enter(ITimedChargeBatteryService service)
        {
        }

        void Tick(ITimedChargeBatteryService service, float deltaTime);

        void Exit(ITimedChargeBatteryService service)
        {
        }
    }
}