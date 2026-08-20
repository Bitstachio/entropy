using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Cannon.Sfx
{
    public sealed class CannonSfxScope : LifetimeScope
    {
        [SerializeField] private AudioClipData cannonShotClipData;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<SfxController<CannonShotEvent>>()
                .WithParameter(cannonShotClipData);
        }
    }
}