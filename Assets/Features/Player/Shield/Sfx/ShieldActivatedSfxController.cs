using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Services.Settings;

namespace Features.Player.Shield.Sfx
{
    public sealed class ShieldActivatedSfxController : SfxController<ShieldActivatedEvent>
    {
        public ShieldActivatedSfxController(
            IEventListener<ShieldActivatedEvent> listener,
            ISettingsService settingsService,
            ISfxPlayer sfxPlayer,
            AudioClipData data)
            : base(listener, settingsService, sfxPlayer, data)
        {
        }
    }
}