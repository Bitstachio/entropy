using System;
using System.Collections;
using Core.Interfaces;
using TMPro;
using UnityEngine;

namespace Features.Targets.Rock
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class RockView : MonoBehaviour, IRockView, IDamageable, ITintable
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private TextMeshPro durabilityDisplay;
        [SerializeField] private ParticleSystem destroyParticles;
        [SerializeField] private float tintFadeDuration = 0.15f;
        
        public event Action<Collision2D> OnHitObject;
        public event Action<float> OnDamageTaken;

        private Rigidbody2D _rb;
        private Color _originalColor;
        private Coroutine _fadeRoutine;

        //===== Lifecycle =====

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _originalColor = spriteRenderer.color;
        }

        //===== API =====

        public void SetPosition(Vector2 position) => transform.position = position;

        public void SetVelocity(Vector2 velocity) => _rb.linearVelocity = velocity;

        public void SetDurability(float durability) => durabilityDisplay.text = Mathf.RoundToInt(durability).ToString();

        public void Destroy()
        {
            SpawnDestroyParticles();
            Destroy(gameObject);
        }

        public void Damage(float amount) => OnDamageTaken?.Invoke(amount);
        
        public void SetTint(Color color)
        {
            Debug.Log($"Setting tint to: {color}");
            StartFade(color);
        }

        public void ResetTint() => StartFade(_originalColor);

        //===== Physics Callbacks =====

        private void OnCollisionEnter2D(Collision2D other) => OnHitObject?.Invoke(other);

        //===== Utilities =====
        
        private void SpawnDestroyParticles() => Instantiate(destroyParticles, transform.position, Quaternion.identity);
        
        private void StartFade(Color targetColor)
        {
            if (_fadeRoutine != null) StopCoroutine(_fadeRoutine);
            _fadeRoutine = StartCoroutine(FadeToColor(targetColor));
        }

        private IEnumerator FadeToColor(Color color)
        {
            var startColor = spriteRenderer.color;
            var elapsed = 0f;

            while (elapsed < tintFadeDuration)
            {
                elapsed += Time.deltaTime;
                spriteRenderer.color = Color.Lerp(startColor, color, elapsed / tintFadeDuration);
                yield return null;
            }

            spriteRenderer.color = color;
            _fadeRoutine = null;
        }
    }
}