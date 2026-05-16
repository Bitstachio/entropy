using System;
using UnityEngine;

namespace Features.Targets.Rock
{
    public interface IRockView
    {
        event Action<Collision2D> OnHitObject;
        event Action<float> OnDamageTaken;

        void SetPosition(Vector2 position);
        void SetVelocity(Vector2 velocity);
        void SetDurability(float durability);
        void Destroy();
    }
}