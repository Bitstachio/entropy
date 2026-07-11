using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Services.Settings;

namespace Core.Upgrade.Sfx
{
    public sealed class UpgradePanelClosedSfxController : SfxController<UpgradePanelClosed>
    {
        public UpgradePanelClosedSfxController(
            IEventListener<UpgradePanelClosed> listener,
            ISettingsService settingsService,
            ISfxPlayer sfxPlayer,
            AudioClipData data)
            : base(listener, settingsService, sfxPlayer, data)
        {
        }
    }
}