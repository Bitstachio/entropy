using Core.UI.SegmentedProgressBar;
using Core.Utils;

namespace Features.Player.Attack.Laser.BatteryDisplay
{
    public sealed class LaserBatteryChargingQuantizer : ISegmentQuantizer
    {
        public int ToStepCount(float normalizedValue, int segmentCount) =>
            MathUtils.NormalizedToStepCount(normalizedValue, segmentCount, false);
    }
}