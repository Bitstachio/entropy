namespace Core.Services.Battery.InstantCharge
{
    public interface IInstantChargeBatteryState
    {
        void Enter(IInstantChargeBatteryService service)
        {
        }

        void Tick(IInstantChargeBatteryService service, float deltaTime);

        void Exit(IInstantChargeBatteryService service)
        {
        }
    }
}