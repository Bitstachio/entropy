using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;

namespace Features.Player.Upgrade.Sfx
{
    public sealed class UpgradePanelOpenedSfxController : SfxController<UpgradePanelOpened>
    {
        public UpgradePanelOpenedSfxController(
            IEventListener<UpgradePanelOpened> listener,
            ISfxPlayer sfxPlayer,
            AudioClipData data)
            : base(listener, sfxPlayer, data)
        {
        }
    }
}