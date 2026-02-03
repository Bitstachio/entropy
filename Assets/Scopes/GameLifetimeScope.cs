using Features.Hazards.Scripts;
using Shared.Interfaces;
using Shared.Providers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public class GameLifetimeScope : LifetimeScope
    {
        //===== Injectables =====

        [SerializeField] private HorizontalBoundsProvider horizontalBoundsProvider;
        
        [SerializeField] private Rock rockPrefab;

        //===== Configuration =====

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(horizontalBoundsProvider).As<IBoundsProvider>();

            builder.Register<RockFactory>(Lifetime.Singleton).WithParameter(rockPrefab);

            builder.RegisterComponentInHierarchy<RockSpawner>();
        }
    }
}