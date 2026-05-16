using System.Linq;
using Core.Tag;
using UnityEngine;

namespace Features.Physics.Scripts
{
    public class KinematicImpulse : MonoBehaviour
    {
        [SerializeField] [Tag] private string[] targets;
        [SerializeField] private float magnitude = 5f;

        //===== Lifecycle =====

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (targets.Contains(other.transform.tag)) ApplyKineticImpulse(other.rigidbody);
        }

        //===== Utilities =====

        // Apply a bounce such that the object always goes up to a fixed height
        private void ApplyKineticImpulse(Rigidbody2D rb)
        {
            var gravity = Mathf.Abs(Physics2D.gravity.y * rb.gravityScale);
            var requiredVelocity = Mathf.Sqrt(2 * gravity * magnitude);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, requiredVelocity);
        }
    }
}