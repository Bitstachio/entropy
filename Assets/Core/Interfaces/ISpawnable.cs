using UnityEngine;

namespace Core.Interfaces
{
    public interface ISpawnable
    {
        void SetPosition(Vector2 position);
        void SetVelocity(Vector2 velocity);
    }
}