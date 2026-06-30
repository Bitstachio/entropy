namespace Core.Services.Battery.InstantCharge
{
    public interface IInstantChargeBatteryService
    {
        IInstantChargeBatteryState State { get; set; }
        float Charge { get; set; }
        float DischargeTime { get; set; }

        void TransitionTo(IInstantChargeBatteryState state);
    }
}