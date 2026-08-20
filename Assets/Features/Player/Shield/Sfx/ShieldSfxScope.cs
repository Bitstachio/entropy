using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Shield.Sfx
{
    public sealed class ShieldSfxScope : LifetimeScope
    {
        [SerializeField] private AudioClipData shieldActivatedClipData;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<SfxController<ShieldActivatedEvent>>()
                .WithParameter(shieldActivatedClipData);
        }
    }
}