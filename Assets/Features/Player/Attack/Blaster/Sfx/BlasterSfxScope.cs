using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Attack.Blaster.Sfx
{
    public sealed class BlasterSfxScope : LifetimeScope
    {
        [FormerlySerializedAs("cannonShotClipData")]
        [SerializeField] private AudioClipData blasterShotClipData;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<SfxController<BlasterShotEvent>>()
                .WithParameter(blasterShotClipData);
        }
    }
}
