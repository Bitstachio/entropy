namespace Features.Progression.Interfaces
{
    public interface IProgressionModel
    {
        public float CurrentScore { get; }
        
        void AddScore(float amount);
    }
}