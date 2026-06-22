using Core.Foundations.Components;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Player.Shield.Countdown
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class ShieldCountdownView : ToggleableView, IShieldCountdownView
    {
        [SerializeField] private Slider slider;
        
        public void SetValue(float value) => slider.value = value;
    }
}