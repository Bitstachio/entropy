namespace Features.Menu.GameOver
{
    public interface IGameOverMenuModel
    {
        public int Score { get; }
        public int HighScore { get; }
        public bool IsNewHighScore { get; }
    }
}