using Features.Hazards.Scripts;
using Shared.Providers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private HorizontalBoundsProvider horizontalBoundsProvider;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(horizontalBoundsProvider);
            
            builder.RegisterComponentInHierarchy<RockSpawner>();
        }
    }
}