using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;
using UnityEngine;

namespace Features.Orchestration.Sfx
{
    public class GameOverSfxController : SfxController<GameOverEvent>
    {
        public GameOverSfxController(
            IEventListener<GameOverEvent> listener,
            ISfxPlayer sfxPlayer,
            AudioClip clip)
            : base(listener, sfxPlayer, clip)
        {
        }
    }
}