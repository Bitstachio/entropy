namespace Features.Progression
{
    public interface IProgressionRepository
    {
        int LoadHighScore();
        void SaveHighScore(int score);
    }
}