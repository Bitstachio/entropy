using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.StatDisplay;
using Core.StatDisplay.Controllers;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Features.StatDisplay;
using Features.StatDisplay.Controllers;

namespace Features.Player.Attack.Laser.StatDisplay
{
    public sealed class LaserDamagePerPulseDisplayController : StatDisplayController<LaserBeamStats>
    {
        public LaserDamagePerPulseDisplayController(
            IEventListener<StatRegistryUpdatedEvent<LaserBeamStats>> listener,
            IStatDisplayView view,
            StatRegistry<LaserBeamStats> statRegistry)
            : base(listener, view, statRegistry, LaserBeamStats.DamagePerPulse)
        {
        }

        protected override string FormatStat(StatRegistryUpdatedEvent<LaserBeamStats> @event) =>
            $"{@event.NewValue:F2} MJ";
    }
}