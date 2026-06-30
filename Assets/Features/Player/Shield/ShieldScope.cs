using Core.Services.Battery.InstantCharge;
using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using Features.Player.Shield.BatteryDisplay;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Shield
{
    public class ShieldScope : LifetimeScope
    {
        [SerializeField] private ShieldView shieldView;
        [SerializeField] private InstantChargeBatteryConfig shieldBatteryConfig;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<InstantChargeBatteryService>()
                .As<IInstantChargeBatteryService>()
                .WithParameter<IInstantChargeBatteryState>(new ShieldBatteryIdleState())
                .WithParameter(shieldBatteryConfig);
            
            builder.RegisterBuildCallback(container =>
            {
                var shieldStats = container.Resolve<StatRegistry<ShieldStats>>();
                // TODO: I wonder if this is a code smell (same as laser scope)
                shieldStats.Register(ShieldStats.Duration, shieldBatteryConfig.DischargeTime);
            });

            builder.Register<IShieldModel, ShieldModel>(Lifetime.Singleton);
            builder.RegisterComponent(shieldView).As<IShieldView>();
            builder.RegisterEntryPoint<ShieldController>();
        }
    }
}