using UnityEngine;

namespace Core.Services.Battery.Rechargeable
{
    [CreateAssetMenu(menuName = "Battery/Rechargeable Battery Config")]
    public class RechargeableBatteryConfig : ScriptableObject
    {
        [SerializeField] private float chargeTime = 10f;
        [SerializeField] private float dischargeTime = 5f;
        
        public float ChargeTime => chargeTime;
        public float DischargeTime => dischargeTime;
    }
}