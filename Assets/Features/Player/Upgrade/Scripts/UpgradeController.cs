using Features.Player.Upgrade.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Player.Upgrade.Scripts
{
    public class UpgradeController : MonoBehaviour
    {
        [SerializeField] private float intervalSeconds;
        [SerializeField] private GameObject offerPanel;
        [SerializeField] private Button[] options;

        private float _elapsed;
        private bool _isOpen;

        //===== Lifecycle =====

        private void Awake() => BindOptionListeners();

        private void Update()
        {
            _elapsed += Time.deltaTime;
            if (!_isOpen && _elapsed >= intervalSeconds) OpenUpgradeOffer();
        }

        //===== Event Handlers =====

        public void OnClickOption() => CloseUpgradeOffer();

        //===== Utilities =====

        private void BindOptionListeners()
        {
            foreach (var option in options)
            {
                var behaviour = option.GetComponent<UpgradeOption>();
                var upgrade = behaviour?.Upgrade;

                // TODO: Improve exception handling when `behaviour` or `upgrade` is null
                if (!upgrade) continue;
                behaviour.SetContent(upgrade.Description);
                option.onClick.AddListener(upgrade.Apply);
            }
        }

        private void OpenUpgradeOffer()
        {
            Time.timeScale = 0f;
            _isOpen = true;
            offerPanel.gameObject.SetActive(true);
        }

        private void CloseUpgradeOffer()
        {
            Time.timeScale = 1f;
            _elapsed = 0f;
            _isOpen = false;
            offerPanel.gameObject.SetActive(false);
        }
    }
}