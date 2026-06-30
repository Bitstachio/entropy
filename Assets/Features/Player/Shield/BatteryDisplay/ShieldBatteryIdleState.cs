using Core.Services.Battery.InstantCharge;

namespace Features.Player.Shield.BatteryDisplay
{
    public sealed class ShieldBatteryIdleState : IInstantChargeBatteryState
    {
        public void Tick(IInstantChargeBatteryService service, float deltaTime)
        {
        }
    }
}