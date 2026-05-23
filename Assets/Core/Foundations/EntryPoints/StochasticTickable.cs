using Core.Validators;
using Random = System.Random;

namespace Core.Foundations.EntryPoints
{
    public abstract class StochasticTickable : PeriodicTickable
    {
        private readonly Random _random;
        private float _probability;

        protected StochasticTickable(Random random, float probability, float interval) : base(interval)
        {
            _random = random;
            _probability = NumericValidator.ValidateProbability(probability);
        }

        //===== Utilities =====

        protected override bool CanExecute() => _random.NextDouble() < _probability;

        protected void UpdateProbability(float probability) =>
            _probability = NumericValidator.ValidateProbability(probability);
    }
}