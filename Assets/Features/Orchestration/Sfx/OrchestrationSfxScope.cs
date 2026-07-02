using Core.Audio;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Orchestration.Sfx
{
    public sealed class OrchestrationSfxScope : LifetimeScope
    {
        [SerializeField] private AudioClipData gameOverClipData;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameOverSfxController>()
                .WithParameter(gameOverClipData);
        }
    }
}