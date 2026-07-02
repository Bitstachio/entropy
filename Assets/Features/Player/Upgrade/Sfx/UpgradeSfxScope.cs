using Core.Audio;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Player.Upgrade.Sfx
{
    public sealed class UpgradeSfxScope : LifetimeScope
    {
        [SerializeField] private AudioClipData upgradePanelOpenedClipData;
        [SerializeField] private AudioClipData upgradePanelClosedClipData;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<UpgradePanelOpenedSfxController>()
                .WithParameter(upgradePanelOpenedClipData);
            builder.RegisterEntryPoint<UpgradePanelClosedSfxController>()
                .WithParameter(upgradePanelClosedClipData);
        }
    }
}