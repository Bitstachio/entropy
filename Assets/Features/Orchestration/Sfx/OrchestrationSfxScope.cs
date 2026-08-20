using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
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
            builder.RegisterEntryPoint<SfxController<GameOverEvent>>()
                .WithParameter(gameOverClipData);
        }
    }
}