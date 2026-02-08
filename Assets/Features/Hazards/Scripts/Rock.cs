using Features.Shared.Interfaces;
using TMPro;
using UnityEngine;

namespace Features.Hazards.Scripts
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
    public sealed class Rock : MonoBehaviour, IDamageable
    {
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
            if ((_durability -= amount) <= 0) Destroy(gameObject);
            else UpdateDurabilityText();
        }

        //===== Utilities =====

        private void UpdateDurabilityText() => durabilityText.text = _durability.ToString("F0");
    }
}