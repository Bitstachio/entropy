using Core.Audio;
using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;

namespace Features.Menu.Sfx
{
    public sealed class MenuOptionSelectedSfxController : SfxController<MenuOptionSelected>
    {
        public MenuOptionSelectedSfxController(
            IEventListener<MenuOptionSelected> listener,
            ISfxPlayer sfxPlayer,
            AudioClipData data)
            : base(listener, sfxPlayer, data)
        {
        }
    }
}