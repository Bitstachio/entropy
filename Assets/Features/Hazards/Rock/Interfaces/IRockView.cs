using System;
using UnityEngine;

namespace Features.Hazards.Rock.Interfaces
{
    public interface IRockView
    {
        event Action OnHitPlayer;
        event Action<float> OnDamageTaken;
        
        void SetPosition(Vector2 position);
        void SetVelocity(Vector2 velocity);
    }
}