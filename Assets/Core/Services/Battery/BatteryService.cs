using Features.Player.Attack.Laser;
using UnityEngine;
using VContainer.Unity;

namespace Core.Services.Battery
{
    public sealed class BatteryService : IBatteryService, ITickable
    {
        public IBatteryState State { get; set; }
        public float Charge { get; set; }
        public float ChargeTime { get; set; }
        public float DischargeTime { get; set; }

        public BatteryService(IBatteryState state, LaserBatteryConfig config)
        {
            State = state;
            ChargeTime = config.ChargeTime;
            DischargeTime = config.DischargeTime;
        }

        //===== Lifecycle =====

        public void Tick() => State.Tick(this, Time.deltaTime);

        //===== API =====

        public void TransitionTo(IBatteryState state)
        {
            State.Exit(this);
            State = state;
            State.Enter(this);
        }
    }
}