using System;
using UnityEngine;

namespace Core.Physics
{
    [RequireComponent(typeof(Collider2D))]
    [DisallowMultipleComponent]
    public sealed class CollisionProxy : MonoBehaviour
    {
        public event Action<Collision2D> OnEnter;
        public event Action<Collision2D> OnStay;
        public event Action<Collision2D> OnExit;

        private Collider2D _collider;
        public Collider2D Collider => _collider ??= GetComponent<Collider2D>();

        private void Awake()
        {
            if (!Collider.isTrigger) return;
            Debug.LogWarning(
                $"[CollisionProxy2D] Component on {gameObject.name} requires its Collider2D to have 'Is Trigger' disabled. Fixing at runtime.",
                this);
            Collider.isTrigger = false;
        }

        private void OnCollisionEnter2D(Collision2D collision) => OnEnter?.Invoke(collision);

        private void OnCollisionStay2D(Collision2D collision) => OnStay?.Invoke(collision);

        private void OnCollisionExit2D(Collision2D collision) => OnExit?.Invoke(collision);

        private void OnDestroy()
        {
            OnEnter = null;
            OnStay = null;
            OnExit = null;
        }
    }
}