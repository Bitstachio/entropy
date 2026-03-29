using Features.Player.Shared.Scripts;
using Features.Shared.Interfaces;
using UnityEngine;

namespace Features.Player.Attack.Scripts
{
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField] private PlayerStats stats;
        
        private Rigidbody2D _rb;

        //===== Lifecycle =====

        private void Awake() => _rb = GetComponent<Rigidbody2D>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Hazard")) return;
            other.GetComponent<IDamageable>()?.Damage(stats.bulletDamage);
            Destroy(gameObject);
        }

        //===== API =====

        public void Launch(Vector2 direction, float speed) => _rb.linearVelocity = direction * speed;
    }
}