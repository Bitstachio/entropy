using UnityEngine;

namespace Features.Player.Attack.Laser
{
    [CreateAssetMenu(menuName = "Player/Weapons/Laser/Laser Battery Config")]
    public sealed class LaserBatteryConfig : ScriptableObject
    {
        [SerializeField] private float chargeTime;
        [SerializeField] private float dischargeTime;
        
        public float ChargeTime => chargeTime;
        public float DischargeTime => dischargeTime;
    }
}