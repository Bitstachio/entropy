using Core.Services.Battery.TimedCharge;
using Core.UI.SegmentedProgressBar;

namespace Features.Player.Attack.Laser.BatteryDisplay
{
    public sealed class LaserBatteryDischargingState : ITimedChargeBatteryState, IQuantizableState
    {
        public ISegmentQuantizer Quantizer { get; } = new LaserBatteryDischargingQuantizer();
        
        public void Tick(ITimedChargeBatteryService service, float deltaTime)
        {
            service.Charge -= deltaTime / service.DischargeTime;
            
            if (!(service.Charge <= 0)) return;
            
            service.Charge = 0;
            service.TransitionTo(new LaserBatteryChargingState());
        }
    }
}