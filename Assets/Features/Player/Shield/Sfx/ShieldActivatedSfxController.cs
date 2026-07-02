using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;

namespace Features.Player.Shield.Sfx
{
    public sealed class ShieldActivatedSfxController : SfxController<ShieldCollectedEvent>
    {
        public ShieldActivatedSfxController(
            IEventListener<ShieldCollectedEvent> listener,
            ISfxPlayer sfxPlayer,
            AudioClipData data)
            : base(listener, sfxPlayer, data)
        {
        }
    }
}