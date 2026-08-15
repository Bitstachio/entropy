using UnityEngine;

namespace Features.Player.Attack.Laser
{
    [CreateAssetMenu(menuName = "Player/Weapons/Laser/Baseline Stats")]
    public sealed class LaserBaselineStats : ScriptableObject
    {
        [SerializeField] private float baselineDamagePerPulse = 1f;
        [SerializeField] private float baselinePulseInterval = 0.5f;

        public float DamagePerPulse => baselineDamagePerPulse;
        public float PulseInterval => baselinePulseInterval;
    }
}