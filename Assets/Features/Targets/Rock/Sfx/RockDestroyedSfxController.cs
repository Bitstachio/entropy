using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;
using UnityEngine;

namespace Features.Targets.Rock.Sfx
{
    public sealed class RockDestroyedSfxController : SfxController<RockDestroyedEvent>
    {
        public RockDestroyedSfxController(
            IEventListener<RockDestroyedEvent> listener,
            ISfxPlayer sfxPlayer,
            AudioClip clip,
            AudioClipConfig config)
            : base(listener, sfxPlayer, clip, config)
        {
        }
    }
}