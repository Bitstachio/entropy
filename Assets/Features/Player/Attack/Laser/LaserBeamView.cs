using System;
using UnityEngine;

namespace Features.Player.Attack.Laser
{
    [RequireComponent(typeof(BoxCollider2D))]
    public sealed class LaserBeamView : MonoBehaviour, ILaserBeamView
    {
        public event Action<Collider2D> OnEnterTrigger;
        public event Action<Collider2D> OnExitTrigger;

        //===== API =====
        
        public void On() => gameObject.SetActive(true);

        public void Off() => gameObject.SetActive(false);

        //===== Physics Callbacks =====
        
        private void OnTriggerEnter2D(Collider2D other) => OnEnterTrigger?.Invoke(other);
        
        private void OnTriggerExit2D(Collider2D other) => OnExitTrigger?.Invoke(other);
    }
}