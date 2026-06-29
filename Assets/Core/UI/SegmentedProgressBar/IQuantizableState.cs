namespace Core.UI.SegmentedProgressBar
{
    public interface IQuantizableState
    {
        ISegmentQuantizer Quantizer { get; }
    }
}