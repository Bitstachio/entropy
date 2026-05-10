using System;
using Features.Player.Attack.Cannon.Interfaces;
using UnityEngine;

namespace Features.Player.Attack.Cannon
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class CannonballView : MonoBehaviour, ICannonballView
    {
        private Rigidbody2D _rb;

        //===== Lifecycle =====

        private void Awake() => _rb = GetComponent<Rigidbody2D>();

        //===== Interface Implementation =====

        public event Action<Collider2D> OnHitObject;

        public void SetPosition(Vector2 position) => transform.position = position;

        public void SetVelocity(Vector2 velocity) => _rb.linearVelocity = velocity;

        public void Destroy() => Destroy(gameObject);

        //===== Physics Callbacks =====

        private void OnTriggerEnter2D(Collider2D other) => OnHitObject?.Invoke(other);
    }
}