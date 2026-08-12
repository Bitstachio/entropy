using System;
using Core.Foundations.Components;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Menu.Main.Guide
{
    public sealed class GuideMenuView : BackNavigablePageView, IGuidePageView
    {
        [SerializeField] private Button missionButton;
        [SerializeField] private Button driverSystemButton;
        [SerializeField] private Button blasterButton;
        [SerializeField] private Button laserButton;
        [SerializeField] private Button shieldButton;

        public event Action OnMissionSelected;
        public event Action OnDriverSystemSelected;
        public event Action OnBlasterSelected;
        public event Action OnLaserSelected;
        public event Action OnShieldSelected;

        //===== Lifecycle =====

        private void Awake()
        {
            missionButton.onClick.AddListener(() => OnMissionSelected?.Invoke());
            driverSystemButton.onClick.AddListener(() => OnDriverSystemSelected?.Invoke());
            blasterButton.onClick.AddListener(() => OnBlasterSelected?.Invoke());
            laserButton.onClick.AddListener(() => OnLaserSelected?.Invoke());
            shieldButton.onClick.AddListener(() => OnShieldSelected?.Invoke());
        }
    }
}