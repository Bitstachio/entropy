using Features.Shared.Interfaces;
using Features.Shared.Managers.Scripts;
using TMPro;
using UnityEngine;

namespace Features.Hazards.Scripts
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
    public sealed class Rock : MonoBehaviour, IDamageable
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private float maxDurability;
        [SerializeField] private TextMeshPro durabilityText;

        private float _durability;

        //===== Lifecycle =====

        private void Awake()
        {
            _durability = maxDurability;
            UpdateDurabilityText();
        }

        //===== Interface Implementation =====

        public void Damage(float amount)
        {
            if ((_durability -= amount) > 0) UpdateDurabilityText();
            else
            {
                Destroy(gameObject);
                gameManager.OnRockDestroyed(maxDurability);
            }
        }

        //===== Event Handlers =====

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player")) gameManager.OnPlayerHitRock();
        }

        //===== Utilities =====

        private void UpdateDurabilityText() => durabilityText.text = _durability.ToString("F0");
    }
}