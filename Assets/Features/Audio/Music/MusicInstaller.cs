using Core.ExtendedBehaviours;
using Features.Audio.Music.Interface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Audio.Music
{
    public class MusicInstaller : Installer
    {
        [SerializeField] private MusicPlayer musicPlayer;
        [SerializeField] private AudioClip backgroundMusic;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent(musicPlayer).As<IMusicPlayer>();

            builder.RegisterEntryPoint<GameMusicController>()
                .WithParameter(backgroundMusic);
        }
    }
}