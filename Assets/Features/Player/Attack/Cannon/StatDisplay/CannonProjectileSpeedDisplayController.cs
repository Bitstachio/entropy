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