using TMPro;
using UnityEngine;

namespace Features.Player.Upgrade
{
    public sealed class UpgradeOptionView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI titleTMP;
        [SerializeField] private TextMeshProUGUI magnitudeTMP;

        //===== API =====

        public void Setup(string title, string magnitude)
        {
            titleTMP.text = title;
            magnitudeTMP.text = magnitude;
        }
    }
}