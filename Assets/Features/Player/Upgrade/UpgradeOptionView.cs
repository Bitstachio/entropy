using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Player.Upgrade
{
    public sealed class UpgradeOptionView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI titleTMP;
        [SerializeField] private TextMeshProUGUI magnitudeTMP;
        [SerializeField] private Button button;

        private Action<int> _onClickedCallback;

        //===== API =====

        public void Setup(string title, string magnitude, int index, Action<int> onClickedCallback)
        {
            titleTMP.text = title;
            magnitudeTMP.text = magnitude;
            _onClickedCallback = onClickedCallback;

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => _onClickedCallback?.Invoke(index));
        }
    }
}