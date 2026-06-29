using Core.Utils;

namespace Core.UI.SegmentedProgressBar
{
    public sealed class SpecialSegmentQuantizer : ISegmentQuantizer
    {
        public int ToStepCount(float normalizedValue, int segmentCount) =>
            MathUtils.NormalizedToStepCount1(normalizedValue, segmentCount);
    }
}