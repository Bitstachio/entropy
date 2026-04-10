using System;
using Features.Progression.Interfaces;

namespace Features.Progression
{
    public class ProgressionModel : IProgressionModel
    {
        private readonly IProgressionRepository _repository;

        public ProgressionModel(IProgressionRepository repository)
        {
            _repository = repository;
            HighScore = repository.LoadHighScore();
        }

        //===== Interface Implementation =====

        public float CurrentScore { get; private set; }
        public float HighScore { get; private set; }

        public void AddScore(float amount)
        {
            CurrentScore += amount;
            HighScore = Math.Max(CurrentScore, HighScore);
        }

        public void UpdateHighScore() =>
            _repository.SaveHighScore((int)Math.Round(HighScore, MidpointRounding.AwayFromZero));
    }
}