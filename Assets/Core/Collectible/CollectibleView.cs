using Core.Foundations.Components;
using UnityEngine;

namespace Core.Collectible
{
    public sealed class CollectibleView : TriggerableView, ICollectibleView
    {
        private Rigidbody2D _rb;

        //===== Lifecycle =====

        private void Awake() => _rb = GetComponent<Rigidbody2D>();

        //===== API =====

        public void SetPosition(Vector2 position) => transform.position = position;

        public void SetVelocity(Vector2 velocity) => _rb.linearVelocity = velocity;

        public void Destroy() => Destroy(gameObject);
    }
}