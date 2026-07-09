using Core.Session;

namespace Features.Menu.GameOver
{
    public sealed class GameOverMenuModel : IGameOverMenuModel
    {
        public int Score { get; }
        public int HighScore { get; }
        public bool IsNewHighScore { get; }

        public GameOverMenuModel(GameSessionData session)
        {
            Score = session.Score;
            HighScore = session.HighScore;
            IsNewHighScore = session.IsNewHighScore;
        }
    }
}