using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.StatDisplay;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Attack.Blaster.StatDisplay
{
    public sealed class BlasterFireRateDisplayController : StatDisplayController<BlasterStats>
    {
        public BlasterFireRateDisplayController(
            IEventListener<StatRegistryUpdatedEvent<BlasterStats>> listener,
            IStatDisplayView view,
            StatRegistry<BlasterStats> statRegistry)
            : base(listener, view, statRegistry, BlasterStats.Interval)
        {
        }

        protected override string FormatStat(StatRegistryUpdatedEvent<BlasterStats> @event) =>
            $"{1 / @event.NewValue:F2} Hz";
    }
}
