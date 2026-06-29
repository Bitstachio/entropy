using Core.StatRegistry;
using Core.StatRegistry.StatKeys;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Shield
{
    public class ShieldScope : LifetimeScope
    {
        [Header("Components")]
        [SerializeField] private ShieldView shieldView;

        [Header("Stats")]
        [SerializeField] private float baselineShieldDuration = 5f;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterBuildCallback(container =>
            {
                var shieldStats = container.Resolve<StatRegistry<ShieldStats>>();
                shieldStats.Register(ShieldStats.Duration, baselineShieldDuration);
            });

            builder.Register<IShieldModel, ShieldModel>(Lifetime.Singleton);
            builder.RegisterComponent(shieldView).As<IShieldView>();
            builder.RegisterEntryPoint<ShieldController>();
        }
    }
}