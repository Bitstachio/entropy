namespace Features.Progression.Interfaces
{
    public interface IProgressionView
    {
        // TODO: Considering changing param types to int
        void SetScore(float score);
        void SetHighScore(float score);
    }
}