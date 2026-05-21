using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.StatDisplay.Controllers.Weapon
{
    public sealed class CannonProjectileSpeedDisplayController : StatDisplayController<CannonStats>
    {
        public CannonProjectileSpeedDisplayController(
            IEventListener<StatRegistryUpdatedEvent<CannonStats>> listener,
            IStatDisplayView view,
            StatRegistry<CannonStats> statRegistry)
            : base(listener, view, statRegistry, CannonStats.ProjectileSpeed)
        {
        }

        protected override string FormatStat(StatRegistryUpdatedEvent<CannonStats> @event) =>
            $"{@event.NewValue:F2} m/s";
    }
}