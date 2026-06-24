using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;
using UnityEngine;

namespace Features.Player.Shield.Collectible.Sfx
{
    public sealed class ShieldCollectedSfxController : SfxController<ShieldCollectedEvent>
    {
        public ShieldCollectedSfxController(
            IEventListener<ShieldCollectedEvent> listener,
            ISfxPlayer sfxPlayer,
            AudioClip clip,
            AudioClipConfig config)
            : base(listener, sfxPlayer, clip, config)
        {
        }
    }
}