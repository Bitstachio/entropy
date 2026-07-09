using Core.Events.Channels;
using Core.Events.Interfaces;

namespace Core.Audio.Sfx.Global
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