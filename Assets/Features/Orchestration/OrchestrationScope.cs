using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Orchestration
{
    public sealed class OrchestrationScope : LifetimeScope
    {
        [SerializeField] private int gameOverDelayMilliseconds;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<Orchestrator>()
                .WithParameter("gameOverDelay", gameOverDelayMilliseconds);
        }
    }
}