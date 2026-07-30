using System;
using Core.Services.Settings;
using VContainer.Unity;

namespace Features.Settings
{
    public sealed class SettingsController : IStartable, IDisposable
    {
        private readonly ISettingsService _service;

        private readonly ISettingsView _view;

        public SettingsController(ISettingsService service, ISettingsView view)
        {
            _service = service;
            _view = view;
        }

        //===== Lifecycle =====

        public void Start()
        {
            _view.OnSettingsChanged += HandleSettingsChanged;

            var data = _service.Load();
            _view.SetMusicVolume(data.MusicVolume);
            _view.SetSfxVolume(data.SfxVolume);
        }

        public void Dispose() => _view.OnSettingsChanged -= HandleSettingsChanged;

        //===== Event Handlers =====

        private void HandleSettingsChanged() => _service.Save(new SettingsData
        {
            MusicVolume = _view.MusicVolume,
            SfxVolume = _view.SfxVolume
        });
    }
}