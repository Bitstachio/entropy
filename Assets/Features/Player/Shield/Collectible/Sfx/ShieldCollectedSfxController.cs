using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;
using UnityEngine;

namespace Features.Player.Shield.Collectible.Sfx
{
    public class ShieldCollectedSfxController : SfxController<ShieldCollectedEvent>
    {
        public ShieldCollectedSfxController(
            IEventListener<ShieldCollectedEvent> listener,
            ISfxPlayer sfxPlayer,
            AudioClip clip)
            : base(listener, sfxPlayer, clip)
        {
        }
    }
}