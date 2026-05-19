using UnityEngine;

namespace Core.Events.Channels
{
    public struct RockHitObjectEvent
    {
        public Collision2D Collision { get; }

        public RockHitObjectEvent(Collision2D collision) => Collision = collision;
    }
}