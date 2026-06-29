namespace Core.UI.SegmentedProgressBar
{
    public interface ISegmentedProgressBarView : IValueDisplay<float>
    {
        void SetQuantizer(ISegmentQuantizer quantizer);
    }
}