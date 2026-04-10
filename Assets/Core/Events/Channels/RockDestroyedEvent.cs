namespace Core.Events.Channels
{
    public struct RockDestroyedEvent
    {
        public float Durability { get; }
        
        public RockDestroyedEvent(float durability) => Durability = durability;
    }
}