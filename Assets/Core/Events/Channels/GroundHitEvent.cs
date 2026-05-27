using UnityEngine;

namespace Core.Events.Channels
{
    public struct GroundHitEvent
    {
        public string Tag { get; }
        
        public GroundHitEvent(string tag) => Tag = tag;
    }
}