namespace Features.Menu.GameOver
{
    public interface IGameOverMenuModel
    {
        public int SceneLoadDelay { get; }
        public int Score { get; }
        public int HighScore { get; }
        public bool IsNewHighScore { get; }
    }
}