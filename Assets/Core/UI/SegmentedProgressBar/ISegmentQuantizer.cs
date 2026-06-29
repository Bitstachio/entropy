namespace Core.UI.SegmentedProgressBar
{
    public interface ISegmentQuantizer
    {
        int ToStepCount(float normalizedValue, int segmentCount);
    }
}