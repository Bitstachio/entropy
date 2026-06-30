namespace Core.Services.Battery.TimedCharge
{
    public interface ITimedChargeBatteryService
    {
        ITimedChargeBatteryState State { get; set; }
        float Charge { get; set; }
        float ChargeTime { get; set; }
        float DischargeTime { get; set; }

        void TransitionTo(ITimedChargeBatteryState state);
    }
}