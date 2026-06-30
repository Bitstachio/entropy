using Core.Services.Battery.Rechargeable;
using Core.UI.SegmentedProgressBar;

namespace Features.Player.Attack.Laser.BatteryDisplay
{
    public sealed class LaserBatteryDischargingState : IRechargeableBatteryState, IQuantizableState
    {
        public ISegmentQuantizer Quantizer { get; } = new LaserBatteryDischargingQuantizer();
        
        public void Tick(IRechargeableBatteryService service, float deltaTime)
        {
            service.Charge -= deltaTime / service.DischargeTime;
            
            if (!(service.Charge <= 0)) return;
            
            service.Charge = 0;
            service.TransitionTo(new LaserBatteryChargingState());
        }
    }
}