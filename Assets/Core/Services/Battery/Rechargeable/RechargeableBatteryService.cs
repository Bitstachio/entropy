using Features.Player.Attack.Laser;
using UnityEngine;
using VContainer.Unity;

namespace Core.Services.Battery.Rechargeable
{
    public sealed class RechargeableBatteryService : IRechargeableBatteryService, ITickable
    {
        public IRechargeableBatteryState State { get; set; }
        public float Charge { get; set; }
        public float ChargeTime { get; set; }
        public float DischargeTime { get; set; }

        public RechargeableBatteryService(IRechargeableBatteryState state, LaserBatteryConfig config)
        {
            State = state;
            ChargeTime = config.ChargeTime;
            DischargeTime = config.DischargeTime;
        }

        //===== Lifecycle =====

        public void Tick() => State.Tick(this, Time.deltaTime);

        //===== API =====

        public void TransitionTo(IRechargeableBatteryState state)
        {
            State.Exit(this);
            State = state;
            State.Enter(this);
        }
    }
}