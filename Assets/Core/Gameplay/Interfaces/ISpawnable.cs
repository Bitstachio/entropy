using UnityEngine;

namespace Core.Gameplay.Interfaces
{
    public interface ISpawnable
    {
        void SetPosition(Vector2 position);
        void SetVelocity(Vector2 velocity);
    }
}