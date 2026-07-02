using Core.Audio;
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
            builder.RegisterEntryPoint<ShieldActivatedSfxController>()
                .WithParameter(shieldActivatedClipData);
        }
    }
}