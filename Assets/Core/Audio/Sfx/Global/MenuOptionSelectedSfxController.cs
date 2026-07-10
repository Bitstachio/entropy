using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Services.Settings;

namespace Core.Audio.Sfx.Global
{
    public sealed class MenuOptionSelectedSfxController : SfxController<MenuOptionSelected>
    {
        public MenuOptionSelectedSfxController(
            IEventListener<MenuOptionSelected> listener,
            ISettingsService settingsService,
            ISfxPlayer sfxPlayer,
            AudioClipData data)
            : base(listener, settingsService, sfxPlayer, data)
        {
        }
    }
}