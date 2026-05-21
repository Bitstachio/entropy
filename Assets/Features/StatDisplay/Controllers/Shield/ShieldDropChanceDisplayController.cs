using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.StatDisplay.Controllers.Shield
{
    public sealed class ShieldDropChanceDisplayController : StatDisplayController<ShieldStats>
    {
        public ShieldDropChanceDisplayController(
            IEventListener<StatRegistryUpdatedEvent<ShieldStats>> listener,
            IStatDisplayView view,
            StatRegistry<ShieldStats> statRegistry)
            : base(listener, view, statRegistry, ShieldStats.DropChance)
        {
        }

        protected override string FormatStat(StatRegistryUpdatedEvent<ShieldStats> @event) =>
            $"{@event.NewValue:F2}%";
    }
}