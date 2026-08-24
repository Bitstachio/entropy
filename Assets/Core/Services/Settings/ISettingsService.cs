using System;

namespace Core.Services.Settings
{
    public interface ISettingsService
    {
        event Action<SettingsData> OnChanged;

        SettingsData Load();
        void Save(SettingsData data);
    }
}