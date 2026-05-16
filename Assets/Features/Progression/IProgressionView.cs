namespace Features.Progression
{
    public interface IProgressionView
    {
        // TODO: Considering changing param types to int
        void SetScore(float score);
        void SetHighScore(float score);
    }
}