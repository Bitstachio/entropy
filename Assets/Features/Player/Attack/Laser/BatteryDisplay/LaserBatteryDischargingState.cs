using Core.Services.Battery;
using Core.UI.SegmentedProgressBar;

namespace Features.Player.Attack.Laser.BatteryDisplay
{
    public sealed class LaserBatteryDischargingState : IBatteryState, IQuantizableState
    {
        public ISegmentQuantizer Quantizer { get; } = new LaserBatteryDischargingQuantizer();
        
        public void Tick(IBatteryService service, float deltaTime)
        {
            service.Charge -= deltaTime / service.DischargeTime;
            
            if (!(service.Charge <= 0)) return;
            
            service.Charge = 0;
            service.TransitionTo(new LaserBatteryChargingState());
        }
    }
}