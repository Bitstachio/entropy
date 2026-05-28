using Core.Session;

namespace Features.Menu.GameOver
{
    public sealed class GameOverMenuModel : IGameOverMenuModel
    {
        public int SceneLoadDelay => _config.SceneLoadDelay;
        public int Score { get; }
        public int HighScore { get; }
        public bool IsNewHighScore { get; }

        private readonly GameOverMenuConfig _config;

        public GameOverMenuModel(GameOverMenuConfig config, GameSessionData session)
        {
            _config = config;
            Score = session.Score;
            HighScore = session.HighScore;
            IsNewHighScore = session.IsNewHighScore;
        }
    }
}