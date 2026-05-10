using System;

namespace Features.Player.Movement.Interfaces
{
    public interface IMovementView
    {
        event Action<float> OnMovementInputDetected;
        
        void SetLinearVelocity(float velocity);
    }
}