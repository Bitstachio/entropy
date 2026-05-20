using Core.Interfaces;
using UnityEngine;

namespace Features.Player.Collectible
{
    public interface ICollectibleView : ITriggerable
    {
        void SetPosition(Vector2 position);
        void SetVelocity(Vector2 velocity);
    }
}