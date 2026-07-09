using Core.Foundations.Components;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Audio.Sfx.Global
{
    public sealed class GlobalSfxInstaller : Installer
    {
        [SerializeField] private SfxPlayer sfxPlayer;
        [SerializeField] private AudioClipData clickClipData;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab(sfxPlayer, Lifetime.Singleton)
                .DontDestroyOnLoad()
                .As<ISfxPlayer>();
            builder.RegisterEntryPoint<MenuOptionSelectedSfxController>()
                .WithParameter(clickClipData);
        }
    }
}