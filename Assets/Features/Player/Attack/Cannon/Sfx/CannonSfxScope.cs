using Core.Audio;
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
            builder.RegisterEntryPoint<CannonShotSfxController>()
                .WithParameter(cannonShotClipData);
        }
    }
}