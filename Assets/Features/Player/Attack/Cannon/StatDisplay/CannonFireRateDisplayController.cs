using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.StatDisplay;
using Core.StatDisplay.Controllers;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Features.StatDisplay;
using Features.StatDisplay.Controllers;

namespace Features.Player.Attack.Cannon.StatDisplay
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