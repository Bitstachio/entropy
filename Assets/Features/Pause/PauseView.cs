using System;
using Core.Foundations.Components;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Pause
{
    public sealed class PauseView : ToggleableView, IPauseView
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button abortButton;

        public event Action OnResumeSelected;
        public event Action OnSettingsSelected;
        public event Action OnRestartSelected;
        public event Action OnAbortSelected;

        //===== Lifecycle =====

        private void Awake()
        {
            resumeButton.onClick.AddListener(() => OnResumeSelected?.Invoke());
            settingsButton.onClick.AddListener(() => OnSettingsSelected?.Invoke());
            restartButton.onClick.AddListener(() => OnRestartSelected?.Invoke());
            abortButton.onClick.AddListener(() => OnAbortSelected?.Invoke());
        }
    }
}