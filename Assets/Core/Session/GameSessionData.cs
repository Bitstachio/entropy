namespace Core.Session
{
    public sealed class GameSessionData
    {
        // public int Score { get; }
        // public int High { get; }
        // TODO: Replace with actual property
        public int Score => 2;
        public int High => 4;
        
        public GameSessionData(int score, int high)
        {
            // Score = score;
            // High = high;
        }
    }
}