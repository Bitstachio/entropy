namespace Core.Services.Settings
{
    public interface ISettingsService
    {
        SettingsData Load();
        void Save(SettingsData data);
    }
}