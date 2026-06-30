using Core.Services.Battery.InstantCharge;
using Core.UI.SegmentedProgressBar;

namespace Features.Player.Shield.BatteryDisplay
{
    public sealed class ShieldBatteryDischargingState : IInstantChargeBatteryState, IQuantizableState
    {
        public ISegmentQuantizer Quantizer { get; } = new StepCountQuantizer(true);

        public void Tick(IInstantChargeBatteryService service, float deltaTime)
        {
            service.Charge -= deltaTime / service.DischargeTime;
            
            if (service.Charge > 0) return;
            
            service.Charge = 0;
            service.TransitionTo(new ShieldBatteryIdleState());
        }
    }
}