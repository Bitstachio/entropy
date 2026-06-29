using Features.Orchestration.Sfx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Orchestration
{
    public sealed class OrchestrationScope : LifetimeScope
    {
        [SerializeField] private int gameOverDelayMilliseconds;

        [Header("Audio Clips")]
        [SerializeField] private AudioClip gameOverClip;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<Orchestrator>()
                .WithParameter("gameOverDelay", gameOverDelayMilliseconds);

            builder.RegisterEntryPoint<GameOverSfxController>()
                .WithParameter(gameOverClip);
        }
    }
}