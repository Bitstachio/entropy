using System;
using UnityEngine;

namespace Core.Physics
{
    [RequireComponent(typeof(Collider2D))]
    [DisallowMultipleComponent]
    public sealed class TriggerProxy : MonoBehaviour
    {
        public event Action<Collider2D> OnEnter;
        public event Action<Collider2D> OnStay;
        public event Action<Collider2D> OnExit;

        private Collider2D _collider;
        public Collider2D Collider => _collider ??= GetComponent<Collider2D>();

        private void Awake()
        {
            if (Collider.isTrigger) return;
            Debug.LogWarning(
                $"[TriggerProxy2D] Component on {gameObject.name} requires its Collider2D to have 'Is Trigger' enabled. Fixing at runtime.",
                this);
            Collider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other) => OnEnter?.Invoke(other);
        
        private void OnTriggerStay2D(Collider2D other) => OnStay?.Invoke(other);
        
        private void OnTriggerExit2D(Collider2D other) => OnExit?.Invoke(other);

        private void OnDestroy()
        {
            OnEnter = null;
            OnStay = null;
            OnExit = null;
        }
    }
}