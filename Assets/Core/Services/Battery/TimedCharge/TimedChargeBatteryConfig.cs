using UnityEngine;

namespace Core.Services.Battery.TimedCharge
{
    [CreateAssetMenu(menuName = "Battery/Timed Charge Battery Config")]
    public class TimedChargeBatteryConfig : ScriptableObject
    {
        [SerializeField] private float chargeTime = 10f;
        [SerializeField] private float dischargeTime = 5f;
        
        public float ChargeTime => chargeTime;
        public float DischargeTime => dischargeTime;
    }
}