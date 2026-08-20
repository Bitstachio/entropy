using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Targets.Rock.Sfx
{
    public sealed class RockSfxScope : LifetimeScope
    {
        [SerializeField] private AudioClipData rockDestroyedClipData;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<SfxController<RockDestroyedEvent>>()
                .WithParameter(rockDestroyedClipData);
        }
    }
}