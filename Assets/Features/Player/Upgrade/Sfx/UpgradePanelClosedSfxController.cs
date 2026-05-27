using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;
using UnityEngine;

namespace Features.Player.Upgrade.Sfx
{
    public class UpgradePanelClosedSfxController : SfxController<UpgradePanelClosed>
    {
        public UpgradePanelClosedSfxController(
            IEventListener<UpgradePanelClosed> listener,
            ISfxPlayer sfxPlayer,
            AudioClip clip)
            : base(listener, sfxPlayer, clip)
        {
        }
    }
}