using UnityEngine;

namespace Core.Interactions
{
    public interface ISpawnable
    {
        void SetPosition(Vector2 position);
        void SetVelocity(Vector2 velocity);
    }
}