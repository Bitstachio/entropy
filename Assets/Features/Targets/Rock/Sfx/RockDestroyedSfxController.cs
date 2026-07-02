using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;

namespace Features.Targets.Rock.Sfx
{
    public sealed class RockDestroyedSfxController : SfxController<RockDestroyedEvent>
    {
        public RockDestroyedSfxController(
            IEventListener<RockDestroyedEvent> listener,
            ISfxPlayer sfxPlayer,
            AudioClipData data)
            : base(listener, sfxPlayer, data)
        {
        }
    }
}