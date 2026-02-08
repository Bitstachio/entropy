using Features.Shared.Interfaces;
using UnityEngine;

namespace Features.Player.Scripts
{
    public sealed class Bullet : MonoBehaviour
    {
        private Rigidbody2D _rb;

        //===== Lifecycle =====

        private void Awake() => _rb = GetComponent<Rigidbody2D>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Hazard")) return;
            other.GetComponent<IDamageable>()?.Damage(1); // TODO: Set up adjustable amount
            Destroy(gameObject);
        }

        //===== API =====

        public void Launch(Vector2 direction, float speed) => _rb.linearVelocity = direction * speed;
    }
}