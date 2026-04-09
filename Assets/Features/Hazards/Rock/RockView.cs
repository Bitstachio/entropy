using System;
using Core.Gameplay.Interfaces;
using Features.Hazards.Rock.Interfaces;
using UnityEngine;

namespace Features.Hazards.Rock
{
    public class RockView : MonoBehaviour, IRockView
    {
        //===== Interface Implementation =====

        public event Action OnHitPlayer;
        public event Action<float> OnDamageTaken;
        
        public Rigidbody2D Rigidbody => GetComponent<Rigidbody2D>();
        
        // TODO: Implement
        public void SetPosition(Vector3 position)
        {
            Debug.Log("Setting position");
        }

        // TODO: Implement
        public void SetVelocity(Vector3 velocity)
        {
            Debug.Log("Setting velocity");
        }

        //===== Physics Callbacks =====

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player")) OnHitPlayer?.Invoke();
            else if (other.gameObject.CompareTag("Bullet"))
            {
                if (other.gameObject.TryGetComponent(out IDamageSource source)) OnDamageTaken?.Invoke(source.Damage);
            }
        }
    }
}