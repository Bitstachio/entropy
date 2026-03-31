using Features.Player.Shared.Scripts;
using Features.Shared.Interfaces;
using UnityEngine;

namespace Features.Player.Attack.Scripts
{
    public sealed class Bullet : MonoBehaviour
    {
        private PlayerManager _playerManager;

        private Rigidbody2D _rb;

        //===== Lifecycle =====

        private void Awake() => _rb = GetComponent<Rigidbody2D>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Hazard")) return;
            if (_playerManager != null)
                other.GetComponent<IDamageable>()?.Damage(_playerManager.CurrentStats.bulletDamage);
            Destroy(gameObject);
        }

        //===== API =====

        public void SetPlayerManager(PlayerManager playerManager) => _playerManager = playerManager;

        public void Launch(Vector2 direction, float speed) => _rb.linearVelocity = direction * speed;
    }
}