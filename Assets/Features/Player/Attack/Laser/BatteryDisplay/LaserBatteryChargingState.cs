using Core.Services.Battery.Rechargeable;
using Core.UI.SegmentedProgressBar;

namespace Features.Player.Attack.Laser.BatteryDisplay
{
    public sealed class LaserBatteryChargingState : IRechargeableBatteryState, IQuantizableState
    {
        public ISegmentQuantizer Quantizer { get; } = new LaserBatteryChargingQuantizer();
        
        public void Tick(IRechargeableBatteryService service, float deltaTime)
        {
            service.Charge += deltaTime / service.ChargeTime;
            
            if (!(service.Charge >= 1)) return;
            
            service.Charge = 1;
            service.TransitionTo(new LaserBatteryIdleState());
        }
    }
}