using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.StatDisplay.Controllers.Weapon
{
    public sealed class CannonballDamageDisplayController : StatDisplayController<CannonballStats>
    {
        public CannonballDamageDisplayController(
            IEventListener<StatRegistryUpdatedEvent<CannonballStats>> listener,
            IStatDisplayView view,
            StatRegistry<CannonballStats> statRegistry)
            : base(listener, view, statRegistry, CannonballStats.Damage)
        {
        }

        protected override string FormatStat(StatRegistryUpdatedEvent<CannonballStats> @event) =>
            $"{@event.NewValue:F2} MJ";
    }
}