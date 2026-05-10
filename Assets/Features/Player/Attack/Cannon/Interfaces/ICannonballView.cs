using System;
using UnityEngine;

namespace Features.Player.Attack.Cannon.Interfaces
{
    public interface ICannonballView
    {
        event Action<Collider2D> OnHitObject;
        
        void SetPosition(Vector2 position);
        void SetVelocity(Vector2 velocity);
        void Destroy();
    }
}