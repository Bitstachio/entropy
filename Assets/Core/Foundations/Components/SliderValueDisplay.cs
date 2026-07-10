using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Foundations.Components
{
    public sealed class SliderValueDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI valueDisplay;
        [SerializeField] private Slider slider;

        //===== Lifecycle =====

        private void OnEnable()
        {
            UpdateText(slider.value);
            slider.onValueChanged.AddListener(UpdateText);
        }

        private void OnDisable() => slider.onValueChanged.RemoveListener(UpdateText);

        //===== Utilities =====

        private void UpdateText(float value) => valueDisplay.text = $"{Mathf.RoundToInt(slider.value * 100)}%";
    }
}