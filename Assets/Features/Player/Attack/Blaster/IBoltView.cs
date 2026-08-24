using System;
using UnityEngine;

namespace Features.Player.Attack.Blaster
{
    public interface IBoltView
    {
        event Action<Collider2D> OnHitObject;
        
        void SetPosition(Vector2 position);
        void SetVelocity(Vector2 velocity);
        void Destroy();
    }
}
