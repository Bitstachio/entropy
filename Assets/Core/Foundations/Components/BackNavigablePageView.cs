using System;
using Core.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Foundations.Components
{
    public class BackNavigablePageView : ToggleableView, IBackNavigablePageView
    {
        [SerializeField] private Button backButton;

        public event Action OnBackSelected;

        //===== Lifecycle =====

        private void Awake() => backButton.onClick.AddListener(() => OnBackSelected?.Invoke());

        //===== API =====

        public override void On()
        {
            base.On();
            backButton.gameObject.SetActive(true);
        }

        public override void Off()
        {
            base.Off();
            backButton.gameObject.SetActive(false);
        }
    }
}