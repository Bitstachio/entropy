using UnityEngine;

namespace Features.Player.Attack.Cannon
{
    [CreateAssetMenu(menuName = "Player/Weapons/Cannon/Baseline Stats")]
    public sealed class CannonBaselineStats : ScriptableObject
    {
        [SerializeField] private float damage = 1f;
        [SerializeField] private float fireRate = 1f;
        [SerializeField] private float projectileSpeed = 10f;

        public float Damage => damage;
        public float FireRate => fireRate;
        public float ProjectileSpeed => projectileSpeed;
    }
}