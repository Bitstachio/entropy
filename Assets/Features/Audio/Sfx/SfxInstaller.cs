using Core.ExtendedBehaviours;
using Features.Audio.Sfx.Controllers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Audio.Sfx
{
    public sealed class SfxInstaller : Installer
    {
        [SerializeField] private SfxPlayer sfxPlayer;
        
        [Header("Audio Clips")]
        [SerializeField] private AudioClip rockDestroyedClip;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent(sfxPlayer).As<ISfxPlayer>();

            builder.RegisterEntryPoint<RockDestroyedSfxController>()
                .WithParameter(rockDestroyedClip);
        }
    }
}