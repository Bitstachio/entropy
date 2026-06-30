using UnityEngine;
using VContainer.Unity;

namespace Core.Services.Battery.InstantCharge
{
    public sealed class InstantChargeBatteryService : IInstantChargeBatteryService, ITickable
    {
        public IInstantChargeBatteryState State { get; set; }
        public float Charge { get; set; }
        public float DischargeTime { get; set; }

        public InstantChargeBatteryService(IInstantChargeBatteryState state, InstantChargeBatteryConfig config)
        {
            State = state;
            DischargeTime = config.DischargeTime;
        }

        //===== Lifecycle =====

        public void Tick() => State.Tick(this, Time.deltaTime);

        //===== API =====

        public void TransitionTo(IInstantChargeBatteryState state)
        {
            State.Exit(this);
            State = state;
            State.Enter(this);
        }
    }
}