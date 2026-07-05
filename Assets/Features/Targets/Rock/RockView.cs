using System;
using Core.Interfaces;
using TMPro;
using UnityEngine;

namespace Features.Targets.Rock
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class RockView : MonoBehaviour, IRockView, IDamageable
    {
        [SerializeField] private TextMeshPro durabilityDisplay;
        [SerializeField] private ParticleSystem destroyParticles;

        private Rigidbody2D _rb;

        //===== Lifecycle =====

        private void Awake() => _rb = GetComponent<Rigidbody2D>();

        //===== Interface Implementation =====

        public event Action<Collision2D> OnHitObject;
        public event Action<float> OnDamageTaken;

        public void SetPosition(Vector2 position) => transform.position = position;

        public void SetVelocity(Vector2 velocity) => _rb.linearVelocity = velocity;

        public void SetDurability(float durability) => durabilityDisplay.text = Mathf.RoundToInt(durability).ToString();

        public void Destroy()
        {
            SpawnDestroyParticles();
            Destroy(gameObject);
        }

        public void Damage(float amount) => OnDamageTaken?.Invoke(amount);

        //===== Physics Callbacks =====

        private void OnCollisionEnter2D(Collision2D other) => OnHitObject?.Invoke(other);

        //===== Utilities =====
        
        private void SpawnDestroyParticles() => Instantiate(destroyParticles, transform.position, Quaternion.identity);
    }
}