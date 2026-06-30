namespace Core.Services.Battery.Rechargeable
{
    public interface IRechargeableBatteryService
    {
        IRechargeableBatteryState State { get; set; }
        float Charge { get; set; }
        float ChargeTime { get; set; }
        float DischargeTime { get; set; }

        void TransitionTo(IRechargeableBatteryState state);
    }
}