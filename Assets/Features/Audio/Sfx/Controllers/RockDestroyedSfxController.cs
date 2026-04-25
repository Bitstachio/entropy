using Core.Events.Channels;
using Core.Events.Interfaces;
using Features.Audio.Sfx.Interfaces;
using UnityEngine;

namespace Features.Audio.Sfx.Controllers
{
    public class RockDestroyedSfxController : SfxController<RockDestroyedEvent>
    {
        public RockDestroyedSfxController(IEventListener<RockDestroyedEvent> listener, ISfxPlayer sfxPlayer,
            AudioClip clip) : base(listener, sfxPlayer, clip)
        {
        }
    }
}