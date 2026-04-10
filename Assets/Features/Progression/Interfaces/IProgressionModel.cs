namespace Features.Progression.Interfaces
{
    public interface IProgressionModel
    {
        public float CurrentScore { get; }
        public float HighScore { get; }
        // TODO: public float isNewHighScore { get; }
        
        void AddScore(float amount);
        // To prevent performance drops from frequent IO, persistence is deferred to `UpdateHighScore`
        // Repository should not be constantly called in `AddScore`
        void UpdateHighScore();
    }
}