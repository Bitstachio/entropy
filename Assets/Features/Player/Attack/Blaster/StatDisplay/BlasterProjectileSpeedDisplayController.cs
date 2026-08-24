using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.StatDisplay;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;

namespace Features.Player.Attack.Blaster.StatDisplay
{
    public sealed class BlasterProjectileSpeedDisplayController : StatDisplayController<BlasterStats>
    {
        public BlasterProjectileSpeedDisplayController(
            IEventListener<StatRegistryUpdatedEvent<BlasterStats>> listener,
            IStatDisplayView view,
            StatRegistry<BlasterStats> statRegistry)
            : base(listener, view, statRegistry, BlasterStats.ProjectileSpeed)
        {
        }

        protected override string FormatStat(StatRegistryUpdatedEvent<BlasterStats> @event) =>
            $"{@event.NewValue:F2} m/s";
    }
}
