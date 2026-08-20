using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Upgrade.Sfx
{
    public sealed class UpgradeSfxScope : LifetimeScope
    {
        [SerializeField] private AudioClipData upgradePanelOpenedClipData;
        [SerializeField] private AudioClipData upgradePanelClosedClipData;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<SfxController<UpgradePanelOpened>>()
                .WithParameter(upgradePanelOpenedClipData);
            builder.RegisterEntryPoint<SfxController<UpgradePanelClosed>>()
                .WithParameter(upgradePanelClosedClipData);
        }
    }
}