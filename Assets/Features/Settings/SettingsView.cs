using System;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Settings
{
    public sealed class SettingsView : MonoBehaviour, ISettingsView
    {
        [SerializeField] private Button saveButton;
        [SerializeField] private Slider musicVolumeSlider;
        [SerializeField] private Slider sfxVolumeSlider;
        
        public event Action OnSaveSelected;
        
        public float MusicVolume => musicVolumeSlider.value;
        public float SfxVolume => sfxVolumeSlider.value;

        //===== Lifecycle =====
        
        private void Awake() => saveButton.onClick.AddListener(() => OnSaveSelected?.Invoke());

        //===== API =====
        
        public void SetMusicVolume(float volume) => musicVolumeSlider.value = volume;

        public void SetSfxVolume(float volume) => sfxVolumeSlider.value = volume;
    }
}