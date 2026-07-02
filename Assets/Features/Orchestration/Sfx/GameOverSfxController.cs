using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;

namespace Features.Orchestration.Sfx
{
    public sealed class GameOverSfxController : SfxController<GameOverEvent>
    {
        public GameOverSfxController(
            IEventListener<GameOverEvent> listener,
            ISfxPlayer sfxPlayer,
            AudioClipData data)
            : base(listener, sfxPlayer, data)
        {
        }
    }
}