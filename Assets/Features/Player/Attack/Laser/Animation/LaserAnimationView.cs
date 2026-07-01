using UnityEngine;

namespace Features.Player.Attack.Laser.Animation
{
    [RequireComponent(typeof(Animator))]
    public sealed class LaserAnimationView : MonoBehaviour, ILaserAnimationView
    {
        private static readonly int DeactivateHash = Animator.StringToHash("Deactivate");

        private Animator _animator;

        //===== Lifecycle =====

        private void Awake() => _animator = GetComponent<Animator>();

        //===== API =====

        public void SetDeactivateTrigger() => _animator.SetTrigger(DeactivateHash);
    }
}