using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;

namespace Features.Environment.Ground.Sfx
{
    public sealed class GroundHitSfxController : SfxController<GroundHitEvent>
    {
        public GroundHitSfxController(
            IEventListener<GroundHitEvent> listener,
            ISfxPlayer sfxPlayer,
            AudioClipData data)
            : base(listener, sfxPlayer, data)
        {
        }
    }
}