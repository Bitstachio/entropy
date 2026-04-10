namespace Core.Events.Channels
{
    public struct RockHitObjectEvent
    {
        public string Tag { get; }

        public RockHitObjectEvent(string tag) => Tag = tag;
    }
}