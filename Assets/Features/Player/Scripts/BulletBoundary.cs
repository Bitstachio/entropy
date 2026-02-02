using UnityEngine;

namespace Features.Player.Scripts
{
    [RequireComponent(typeof(BoxCollider2D))]
    public sealed class BulletBoundary : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other) => Destroy(other.gameObject);
    }
}