using Core.Interfaces;
using UnityEngine;

namespace Core.Foundations.Components
{
    [RequireComponent(typeof(CanvasGroup))]
    public class HideableView : MonoBehaviour, IToggleable
    {
        private CanvasGroup _canvasGroup;

        //===== Lifecycle =====

        private void Awake() => _canvasGroup = GetComponent<CanvasGroup>();

        //===== API =====

        public void On() => SetVisible(true);

        public void Off() => SetVisible(false);

        //===== Utilities =====

        private void SetVisible(bool isVisible)
        {
            _canvasGroup.alpha = isVisible ? 1f : 0f;
            _canvasGroup.blocksRaycasts = isVisible;
            _canvasGroup.interactable = isVisible;
        }
    }
}