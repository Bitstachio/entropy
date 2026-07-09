using System;
using Core.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Foundations.Components
{
    public class BackNavigablePageView : MonoBehaviour, IBackNavigablePageView
    {
        [SerializeField] private Button backButton;
        
        public event Action OnBackSelected;

        //===== Lifecycle =====
        
        private void Awake() => backButton.onClick.AddListener(() => OnBackSelected?.Invoke());    
    }
}