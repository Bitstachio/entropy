using UnityEngine;

namespace Core.Services.Battery.InstantCharge
{
    [CreateAssetMenu(menuName = "Battery/Instant Charge Battery Config")]
    public sealed class InstantChargeBatteryConfig : ScriptableObject
    {
        [SerializeField] private float dischargeTime = 5f;
        
        public float DischargeTime => dischargeTime;
    }
}