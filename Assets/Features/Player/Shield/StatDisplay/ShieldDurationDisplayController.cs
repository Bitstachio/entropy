using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.StatDisplay;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Shield.StatDisplay
{
    public sealed class ShieldDurationDisplayController : StatDisplayController<ShieldStats>
    {
        public ShieldDurationDisplayController(
            IEventListener<StatRegistryUpdatedEvent<ShieldStats>> listener,
            IStatDisplayView view,
            StatRegistry<ShieldStats> statRegistry)
            : base(listener, view, statRegistry, ShieldStats.Duration)
        {
        }

        protected override string FormatStat(StatRegistryUpdatedEvent<ShieldStats> @event) =>
            $"{@event.NewValue:F2} s";
    }
}