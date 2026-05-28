using Core.Audio.Sfx;
using Core.Events.Channels;
using Core.Events.Interfaces;
using UnityEngine;

namespace Features.Menu.Sfx
{
    public sealed class MenuOptionSelectedSfxController : SfxController<MenuOptionSelected>
    {
        public MenuOptionSelectedSfxController(
            IEventListener<MenuOptionSelected> listener,
            ISfxPlayer sfxPlayer,
            AudioClip clip)
            : base(listener, sfxPlayer, clip)
        {
        }
    }
}