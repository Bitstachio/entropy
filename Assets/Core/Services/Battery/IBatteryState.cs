namespace Core.Services.Battery
{
    public interface IBatteryState
    {
        void Enter(IBatteryService service);
        void Tick(IBatteryService service, float deltaTime);
        void Exit(IBatteryService service);
    }
}