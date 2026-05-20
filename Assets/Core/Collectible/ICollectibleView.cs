using Core.Interfaces;
using UnityEngine;

namespace Core.Collectible
{
    public interface ICollectibleView : ITriggerable
    {
        void SetPosition(Vector2 position);
        void SetVelocity(Vector2 velocity);
        void Destroy();
    }
}