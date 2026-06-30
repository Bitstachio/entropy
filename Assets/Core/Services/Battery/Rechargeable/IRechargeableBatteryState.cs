namespace Core.Services.Battery.Rechargeable
{
    public interface IRechargeableBatteryState
    {
        void Enter(IRechargeableBatteryService service)
        {
        }

        void Tick(IRechargeableBatteryService service, float deltaTime);

        void Exit(IRechargeableBatteryService service)
        {
        }
    }
}