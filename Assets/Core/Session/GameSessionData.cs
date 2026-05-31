namespace Core.Session
{
    public sealed class GameSessionData
    {
        public int Score { get; set; }
        public int HighScore { get; set; }
        public bool IsNewHighScore { get; set; }
    }
}