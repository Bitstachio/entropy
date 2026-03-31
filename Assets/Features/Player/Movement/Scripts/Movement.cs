using Features.Player.Shared.Scripts;
using UnityEngine;

namespace Features.Player.Movement.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Movement : MonoBehaviour
    {
        [SerializeField] private PlayerManager playerManager;

        private GameControls _controls;
        private Rigidbody2D _rb;
        private float _horizontalInput;

        //===== Lifecycle =====

        private void Awake()
        {
            _controls = new GameControls();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable() => _controls.Enable();
        private void OnDisable() => _controls.Disable();

        private void Update() => _horizontalInput = _controls.Player.Move.ReadValue<float>();

        private void FixedUpdate()
        {
            _rb.linearVelocity = Mathf.Abs(_horizontalInput) < 0.01f
                ? Vector2.zero
                : new Vector2(_horizontalInput * playerManager.CurrentStats.movementSpeed, 0);
        }
    }
}