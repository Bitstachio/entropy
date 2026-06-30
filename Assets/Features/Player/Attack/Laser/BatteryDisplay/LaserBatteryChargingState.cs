using Core.Services.Battery.TimedCharge;
using Core.UI.SegmentedProgressBar;

namespace Features.Player.Attack.Laser.BatteryDisplay
{
    public sealed class LaserBatteryChargingState : ITimedChargeBatteryState, IQuantizableState
    {
        public ISegmentQuantizer Quantizer { get; } = new StepCountQuantizer(false);
        
        public void Tick(ITimedChargeBatteryService service, float deltaTime)
        {
            service.Charge += deltaTime / service.ChargeTime;
            
            if (!(service.Charge >= 1)) return;
            
            service.Charge = 1;
            service.TransitionTo(new LaserBatteryIdleState());
        }
    }
}