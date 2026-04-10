namespace Core.Events.Channels
{
    public struct ScoreUpdatedEvent
    {
        public float Score { get; }

        public ScoreUpdatedEvent(float score) => Score = score;
    }
}