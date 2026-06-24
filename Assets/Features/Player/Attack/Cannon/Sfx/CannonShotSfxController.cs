using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;
using UnityEngine;

namespace Features.Player.Attack.Cannon.Sfx
{
    public class CannonShotSfxController : SfxController<CannonShotEvent>
    {
        public CannonShotSfxController(
            IEventListener<CannonShotEvent> listener,
            ISfxPlayer sfxPlayer,
            AudioClip clip,
            AudioClipConfig config)
            : base(listener, sfxPlayer, clip, config)
        {
        }
    }
}