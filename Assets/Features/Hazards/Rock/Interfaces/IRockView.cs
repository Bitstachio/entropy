using System;
using UnityEngine;

namespace Features.Hazards.Rock.Interfaces
{
    public interface IRockView
    {
        event Action OnHitPlayer;
        event Action<float> OnDamageTaken;
        
        Rigidbody2D Rigidbody { get; }
        
        void SetPosition(Vector3 position);
        void SetVelocity(Vector3 velocity);
    }
}