using Core.Utils;

namespace Core.UI.SegmentedProgressBar
{
    public sealed class LinearSegmentQuantizer : ISegmentQuantizer
    {
        public int ToStepCount(float normalizedValue, int segmentCount) =>
            MathUtils.NormalizedToStepCount(normalizedValue, segmentCount);
    }
}