using Core.Foundations.Components;
using UnityEngine;

namespace Features.Player.Shield.Countdown
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class ShieldCountdownView : HideableView, IShieldCountdownView
    {
        public void SetRemainingTime(float time) => Debug.Log($"Remaining time: {time}");
    }
}