using System;
using Core.Interactions;
using Features.Hazards.Rock.Interfaces;
using TMPro;
using UnityEngine;

namespace Features.Hazards.Rock
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RockView : MonoBehaviour, IRockView
    {
        [SerializeField] private TextMeshPro durabilityDisplay;

        private Rigidbody2D _rb;

        //===== Lifecycle =====

        private void Awake() => _rb = GetComponent<Rigidbody2D>();

        //===== Interface Implementation =====

        public event Action<Collision2D> OnHitObject;
        public event Action<float> OnDamageTaken;

        public void SetPosition(Vector2 position) => transform.position = position;

        public void SetVelocity(Vector2 velocity) => _rb.linearVelocity = velocity;

        public void SetDurability(float durability) => durabilityDisplay.text = Mathf.RoundToInt(durability).ToString();

        public void Destroy() => Destroy(gameObject);

        //===== Physics Callbacks =====

        private void OnCollisionEnter2D(Collision2D other) => OnHitObject?.Invoke(other);

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Bullet") && other.gameObject.TryGetComponent(out IDamageSource source))
                OnDamageTaken?.Invoke(source.Damage);
        }
    }
}