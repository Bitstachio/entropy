using Core.Utils;

namespace Core.UI.SegmentedProgressBar
{
    public sealed class StepCountQuantizer : ISegmentQuantizer
    {
        private readonly bool _roundUp;

        public StepCountQuantizer(bool roundUp) => _roundUp = roundUp;

        public int ToStepCount(float normalizedValue, int segmentCount) =>
            MathUtils.NormalizedToStepCount(normalizedValue, segmentCount, _roundUp);
    }
}