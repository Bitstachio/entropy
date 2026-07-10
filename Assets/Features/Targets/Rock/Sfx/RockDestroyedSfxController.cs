using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Services.Settings;

namespace Features.Targets.Rock.Sfx
{
    public sealed class RockDestroyedSfxController : SfxController<RockDestroyedEvent>
    {
        public RockDestroyedSfxController(
            IEventListener<RockDestroyedEvent> listener,
            ISettingsService settingsService,
            ISfxPlayer sfxPlayer,
            AudioClipData data)
            : base(listener, settingsService, sfxPlayer, data)
        {
        }
    }
}