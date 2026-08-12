using System;
using Core.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Foundations.Components
{
    public class BackNavigablePageView : ToggleableView, IBackNavigablePageView
    {
        [SerializeField] private Button backButton;

        public event Action<IBackNavigablePageView> OnBackSelected;

        //===== API =====

        public override void On()
        {
            base.On();
            backButton.gameObject.SetActive(true);
            backButton.onClick.AddListener(HandleBackClicked);
        }

        public override void Off()
        {
            base.Off();
            backButton.gameObject.SetActive(false);
            backButton.onClick.RemoveListener(HandleBackClicked);
        }

        //===== Event Handlers =====

        private void HandleBackClicked() => OnBackSelected?.Invoke(this);
    }
}