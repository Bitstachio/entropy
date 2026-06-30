using UnityEngine;
using VContainer.Unity;

namespace Core.Services.Battery.TimedCharge
{
    public sealed class TimedChargeBatteryService : ITimedChargeBatteryService, ITickable
    {
        public ITimedChargeBatteryState State { get; set; }
        public float Charge { get; set; }
        public float ChargeTime { get; set; }
        public float DischargeTime { get; set; }

        public TimedChargeBatteryService(ITimedChargeBatteryState state, TimedChargeBatteryConfig config)
        {
            State = state;
            ChargeTime = config.ChargeTime;
            DischargeTime = config.DischargeTime;
        }

        //===== Lifecycle =====

        public void Tick() => State.Tick(this, Time.deltaTime);

        //===== API =====

        public void TransitionTo(ITimedChargeBatteryState state)
        {
            State.Exit(this);
            State = state;
            State.Enter(this);
        }
    }
}