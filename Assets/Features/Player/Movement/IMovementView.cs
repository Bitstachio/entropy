using System;

namespace Features.Player.Movement
{
    public interface IMovementView
    {
        event Action<float> OnMovementInputDetected;

        public float XPosition { get; }
        
        void SetLinearVelocity(float velocity);
    }
}