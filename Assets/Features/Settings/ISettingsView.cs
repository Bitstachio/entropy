using System;

namespace Features.Settings
{
    public interface ISettingsView
    {
        event Action OnSaveSelected;

        public float MusicVolume { get; }
        public float SfxVolume { get; }
        
        void SetMusicVolume(float volume);
        void SetSfxVolume(float volume);
    }
}