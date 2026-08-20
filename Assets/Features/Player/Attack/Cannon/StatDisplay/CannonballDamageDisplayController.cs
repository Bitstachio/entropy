using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.StatDisplay;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Attack.Cannon.StatDisplay
{
    public sealed class CannonballDamageDisplayController : StatDisplayController<CannonStats>
    {
        public CannonballDamageDisplayController(
            IEventListener<StatRegistryUpdatedEvent<CannonStats>> listener,
            IStatDisplayView view,
            StatRegistry<CannonStats> statRegistry)
            : base(listener, view, statRegistry, CannonStats.Damage)
        {
        }

        protected override string FormatStat(StatRegistryUpdatedEvent<CannonStats> @event) =>
            $"{@event.NewValue:F2} MJ";
    }
}