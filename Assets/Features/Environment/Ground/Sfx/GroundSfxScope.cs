using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Environment.Ground.Sfx
{
    public sealed class GroundSfxScope : LifetimeScope
    {
        [SerializeField] private AudioClipData groundHitClipData;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<SfxController<GroundHitEvent>>()
                .WithParameter(groundHitClipData);
        }
    }
}