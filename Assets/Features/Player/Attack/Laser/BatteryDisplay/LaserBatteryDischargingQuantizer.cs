using Core.UI.SegmentedProgressBar;
using Core.Utils;

namespace Features.Player.Attack.Laser.BatteryDisplay
{
    public sealed class LaserBatteryDischargingQuantizer : ISegmentQuantizer
    {
        public int ToStepCount(float normalizedValue, int segmentCount) =>
            MathUtils.NormalizedToStepCount(normalizedValue, segmentCount);
    }
}