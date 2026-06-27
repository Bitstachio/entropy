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