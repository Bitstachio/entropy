using Features.Shared.Interfaces;
using Features.Shared.Managers.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Features.Hazards.Scripts
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
    public sealed class Rock : MonoBehaviour, IDamageable
    {
        [SerializeField] private UnityEvent<float> onRockDestroyed;
        [SerializeField] private UnityEvent onRockHitPlayer;

        [SerializeField] private float maxDurability;
        [SerializeField] private TextMeshPro durabilityText;

        private GameManager _gameManager;
        private float _durability;

        //===== Lifecycle =====

        private void Awake()
        {
            _durability = maxDurability;
            UpdateDurabilityText();
        }

        private void Start()
        {
            _gameManager = GameManager.Instance;
            if (_gameManager == null)
            {
                Debug.LogError($"{nameof(Rock)}: GameManager.Instance is null");
                return;
            }

            onRockDestroyed.AddListener(_gameManager.OnRockDestroyed);
            onRockHitPlayer.AddListener(_gameManager.OnPlayerHitRock);
        }

        //===== Interface Implementation =====

        public void Damage(float amount)
        {
            if ((_durability -= amount) > 0) UpdateDurabilityText();
            else
            {
                Destroy(gameObject);
                onRockDestroyed.Invoke(maxDurability);
            }
        }

        //===== Event Handlers =====

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player")) onRockHitPlayer.Invoke();
        }

        //===== Utilities =====

        private void UpdateDurabilityText() => durabilityText.text = _durability.ToString("F0");
    }
}