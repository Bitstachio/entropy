using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Services.Settings;

namespace Features.Player.Attack.Cannon.Sfx
{
    public class CannonShotSfxController : SfxController<CannonShotEvent>
    {
        public CannonShotSfxController(
            IEventListener<CannonShotEvent> listener,
            ISettingsService settingsService,
            ISfxPlayer sfxPlayer,
            AudioClipData data)
            : base(listener, settingsService, sfxPlayer, data)
        {
        }
    }
}