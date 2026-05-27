using System;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Menu.GameOver
{
    public sealed class GameOverMenuView : MonoBehaviour, IGameOverMenuView
    {
        public event Action OnRetrySelected;
        public event Action OnHomeSelected;

        [SerializeField] private Button retryButton;
        [SerializeField] private Button homeButton;

        //===== Lifecycle =====
        
        private void Awake()
        {
            retryButton.onClick.AddListener(() => OnRetrySelected?.Invoke());
            homeButton.onClick.AddListener(() => OnHomeSelected?.Invoke());
        }

        private void OnDestroy()
        {
            retryButton.onClick.RemoveAllListeners();
            homeButton.onClick.RemoveAllListeners();
        }
    }
}