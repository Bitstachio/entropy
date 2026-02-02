using UnityEngine;

namespace Features.Player.Scripts
{
    public sealed class Bullet : MonoBehaviour
    {
        private Rigidbody2D _rb;

        //===== Lifecycle =====

        private void Awake() => _rb = GetComponent<Rigidbody2D>();
        
        //===== API =====

        public void Launch(Vector2 direction, float speed) => _rb.linearVelocity = direction * speed;
    }
}