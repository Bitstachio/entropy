using UnityEngine;

namespace Core.Services.Settings
{
    public sealed class SettingsService : ISettingsService
    {
        private const string MusicVolumeKey = "Settings.MusicVolume";
        private const string SfxVolumeKey = "Settings.SfxVolume";

        public SettingsData Load()
        {
            return new SettingsData
            {
                // Using a scriptable object to configure default values is technically best practice
                // However, for this simple settings setup, it would be overkill
                MusicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 1f),
                SfxVolume = PlayerPrefs.GetFloat(SfxVolumeKey, 1f)
            };
        }

        public void Save(SettingsData data)
        {
            PlayerPrefs.SetFloat(MusicVolumeKey, data.MusicVolume);
            PlayerPrefs.SetFloat(SfxVolumeKey, data.SfxVolume);
            PlayerPrefs.Save();
        }
    }
}