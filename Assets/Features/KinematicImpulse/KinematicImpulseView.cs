using System;
using UnityEngine;

namespace Features.KinematicImpulse
{
    public sealed class KinematicImpulseView : MonoBehaviour, IKinematicImpulseView
    {
        public event Action<Collision2D> OnCollided;
        
        private void OnCollisionEnter2D(Collision2D other) => OnCollided?.Invoke(other);
    }
}