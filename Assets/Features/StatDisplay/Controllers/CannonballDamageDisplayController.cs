using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.StatRegistry.StatKeys;

namespace Features.StatDisplay.Controllers
{
    public class CannonballDamageDisplayController : StatDisplayController<StatRegistryUpdatedEvent<CannonballStats>>
    {
        public CannonballDamageDisplayController(IEventListener<StatRegistryUpdatedEvent<CannonballStats>> listener,
            IStatDisplayView view) : base(listener, view)
        {
        }

        protected override string FormatStat(StatRegistryUpdatedEvent<CannonballStats> @event) =>
            @event.Key == CannonballStats.Damage ? $"{@event.NewValue:F2} MJ" : null;
    }
}