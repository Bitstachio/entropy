using UnityEngine;

namespace Features.Player.Attack.Blaster
{
    [CreateAssetMenu(menuName = "Player/Weapons/Blaster/Blaster Baseline Stats")]
    public sealed class BlasterBaselineStats : ScriptableObject
    {
        [SerializeField] private float damage = 1f;
        [SerializeField] private float fireRate = 1f;
        [SerializeField] private float projectileSpeed = 12f;

        public float Damage => damage;
        public float FireRate => fireRate;
        public float ProjectileSpeed => projectileSpeed;
    }
}
