using System;
using UnityEngine;

namespace Features.Environment.Ground
{
    public sealed class GroundView : MonoBehaviour, IGroundView
    {
        public event Action<Collision2D> OnCollided;
        
        private void OnCollisionEnter2D(Collision2D other) => OnCollided?.Invoke(other);
    }
}