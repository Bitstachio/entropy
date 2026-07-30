using System;

namespace Features.Settings
{
    public interface ISettingsView
    {
        event Action OnSettingsChanged;

        public float MusicVolume { get; }
        public float SfxVolume { get; }

        void SetMusicVolume(float volume);
        void SetSfxVolume(float volume);
    }
}