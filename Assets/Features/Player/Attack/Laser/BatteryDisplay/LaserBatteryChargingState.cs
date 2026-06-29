using Core.Services.Battery;
using Core.UI.SegmentedProgressBar;

namespace Features.Player.Attack.Laser.BatteryDisplay
{
    public sealed class LaserBatteryChargingState : IBatteryState, IQuantizableState
    {
        public ISegmentQuantizer Quantizer { get; } = new LaserBatteryChargingQuantizer();
        
        public void Tick(IBatteryService service, float deltaTime)
        {
            service.Charge += deltaTime / service.ChargeTime;
            
            if (!(service.Charge >= 1)) return;
            
            service.Charge = 1;
            service.TransitionTo(new LaserBatteryIdleState());
        }
    }
}