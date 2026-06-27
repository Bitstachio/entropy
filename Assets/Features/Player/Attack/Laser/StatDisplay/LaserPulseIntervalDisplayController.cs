using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.StatDisplay;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Attack.Laser.StatDisplay
{
    public sealed class LaserPulseIntervalDisplayController : StatDisplayController<LaserBeamStats>
    {
        public LaserPulseIntervalDisplayController(
            IEventListener<StatRegistryUpdatedEvent<LaserBeamStats>> listener,
            IStatDisplayView view,
            StatRegistry<LaserBeamStats> statRegistry)
            : base(listener, view, statRegistry, LaserBeamStats.PulseInterval)
        {
        }

        protected override string FormatStat(StatRegistryUpdatedEvent<LaserBeamStats> @event) =>
            $"{@event.NewValue:F2} s";
    }
}