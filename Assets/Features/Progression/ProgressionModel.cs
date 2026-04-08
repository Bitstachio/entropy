using Features.Progression.Interfaces;

namespace Features.Progression
{
    public class ProgressionModel : IProgressionModel
    {
        public float CurrentScore { get; private set; }

        public void AddScore(float amount) => CurrentScore += amount;
    }
}