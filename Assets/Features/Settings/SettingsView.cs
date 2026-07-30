using System;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Settings
{
    public sealed class SettingsView : MonoBehaviour, ISettingsView
    {
        [SerializeField] private Slider musicVolumeSlider;
        [SerializeField] private Slider sfxVolumeSlider;

        public event Action OnSettingsChanged;

        public float MusicVolume => musicVolumeSlider.value;
        public float SfxVolume => sfxVolumeSlider.value;

        //===== Lifecycle =====

        private void OnEnable()
        {
            musicVolumeSlider.onValueChanged.AddListener(HandleSettingsChanged);
            sfxVolumeSlider.onValueChanged.AddListener(HandleSettingsChanged);
        }

        private void OnDisable()
        {
            musicVolumeSlider.onValueChanged.RemoveListener(HandleSettingsChanged);
            sfxVolumeSlider.onValueChanged.RemoveListener(HandleSettingsChanged);
        }

        //===== Event Handlers =====

        private void HandleSettingsChanged(float _) => OnSettingsChanged?.Invoke();

        //===== API =====

        public void SetMusicVolume(float volume) => musicVolumeSlider.value = volume;

        public void SetSfxVolume(float volume) => sfxVolumeSlider.value = volume;
    }
}