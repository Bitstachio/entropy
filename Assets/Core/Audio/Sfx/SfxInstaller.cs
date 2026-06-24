using Core.Foundations.Components;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Audio.Sfx
{
    public sealed class SfxInstaller : Installer
    {
        [SerializeField] private SfxPlayer sfxPlayer;
        [SerializeField] private AudioClipConfig defaultConfig;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent(sfxPlayer).As<ISfxPlayer>();
            builder.RegisterComponent(defaultConfig).As<AudioClipConfig>();
        }
    }
}