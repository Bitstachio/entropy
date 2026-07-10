using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Services.Settings;

namespace Features.Player.Upgrade.Sfx
{
    public sealed class UpgradePanelOpenedSfxController : SfxController<UpgradePanelOpened>
    {
        public UpgradePanelOpenedSfxController(
            IEventListener<UpgradePanelOpened> listener,
            ISettingsService settingsService,
            ISfxPlayer sfxPlayer,
            AudioClipData data)
            : base(listener, settingsService, sfxPlayer, data)
        {
        }
    }
}