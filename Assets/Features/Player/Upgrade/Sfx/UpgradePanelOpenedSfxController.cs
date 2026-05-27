using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Features.Audio.Sfx;
using UnityEngine;

namespace Features.Player.Upgrade.Sfx
{
    public sealed class UpgradePanelOpenedSfxController : SfxController<UpgradePanelOpened>
    {
        public UpgradePanelOpenedSfxController(
            IEventListener<UpgradePanelOpened> listener,
            ISfxPlayer sfxPlayer,
            AudioClip clip)
            : base(listener, sfxPlayer, clip)
        {
        }
    }
}