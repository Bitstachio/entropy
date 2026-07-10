using System;
using Core.Foundations.Components;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Menu.Main
{
    public sealed class MainPageView : ToggleableView, IMainPageView
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button guideButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button creditsButton;

        public event Action OnStartSelected;
        public event Action OnGuideSelected;
        public event Action OnSettingsSelected;
        public event Action OnCreditsSelected;

        //===== Lifecycle =====

        private void Awake()
        {
            startButton.onClick.AddListener(HandleStartSelected);
            guideButton.onClick.AddListener(HandleGuideSelected);
            settingsButton.onClick.AddListener(HandleSettingsSelected);
            creditsButton.onClick.AddListener(HandleCreditsSelected);
        }

        //===== Event Handlers =====

        private void HandleStartSelected() => OnStartSelected?.Invoke();

        private void HandleGuideSelected() => OnGuideSelected?.Invoke();

        private void HandleSettingsSelected() => OnSettingsSelected?.Invoke();
        
        private void HandleCreditsSelected() => OnCreditsSelected?.Invoke();
    }
}