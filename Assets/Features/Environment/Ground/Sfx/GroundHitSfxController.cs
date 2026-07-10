using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Services.Settings;

namespace Features.Environment.Ground.Sfx
{
    public sealed class GroundHitSfxController : SfxController<GroundHitEvent>
    {
        public GroundHitSfxController(
            IEventListener<GroundHitEvent> listener,
            ISettingsService settingsService,
            ISfxPlayer sfxPlayer,
            AudioClipData data)
            : base(listener, settingsService, sfxPlayer, data)
        {
        }
    }
}