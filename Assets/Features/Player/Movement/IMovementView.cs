using System;

namespace Features.Player.Movement
{
    public interface IMovementView
    {
        event Action<float> OnMovementInputDetected;
        
        void SetLinearVelocity(float velocity);
    }
}