using Core.Foundations.Components;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Audio.Music
{
    public sealed class MusicInstaller : Installer
    {
        [SerializeField] private MusicPlayer musicPlayer;
        [SerializeField] private AudioClip backgroundMusic;
        [SerializeField] private AudioClipData audioClipData;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent(musicPlayer).As<IMusicPlayer>();

            builder.RegisterEntryPoint<GameMusicController>()
                .WithParameter(backgroundMusic)
                .WithParameter(audioClipData);
        }
    }
}