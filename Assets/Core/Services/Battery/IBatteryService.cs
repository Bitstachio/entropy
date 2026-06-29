namespace Core.Services.Battery
{
    public interface IBatteryService
    {
        IBatteryState State { get; set; }
        float Charge { get; set; }
        float ChargeTime { get; set; }
        float DischargeTime { get; set; }

        void TransitionTo(IBatteryState state);
    }
}