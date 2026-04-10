namespace Features.Progression.Interfaces
{
    public interface IProgressionRepository
    {
        int LoadHighScore();
        void SaveHighScore(int score);
    }
}