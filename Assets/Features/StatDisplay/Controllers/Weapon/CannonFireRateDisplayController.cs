using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.StatDisplay.Controllers.Weapon
{
    public sealed class CannonFireRateDisplayController : StatDisplayController<CannonStats>
    {
        public CannonFireRateDisplayController(
            IEventListener<StatRegistryUpdatedEvent<CannonStats>> listener,
            IStatDisplayView view,
            StatRegistry<CannonStats> statRegistry)
            : base(listener, view, statRegistry, CannonStats.Interval)
        {
        }

        protected override string FormatStat(StatRegistryUpdatedEvent<CannonStats> @event) =>
            $"{1 / @event.NewValue:F2} Hz";
    }
}