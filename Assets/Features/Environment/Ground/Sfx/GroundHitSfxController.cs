using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;
using UnityEngine;

namespace Features.Environment.Ground.Sfx
{
    public sealed class GroundHitSfxController : SfxController<GroundHitEvent>
    {
        public GroundHitSfxController(
            IEventListener<GroundHitEvent> listener,
            ISfxPlayer sfxPlayer,
            AudioClip clip,
            AudioClipConfig config)
            : base(listener, sfxPlayer, clip, config)
        {
        }
    }
}