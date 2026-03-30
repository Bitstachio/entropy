using UnityEngine;

namespace Features.Upgrade.Scripts
{
    public class UpgradeOfferController : MonoBehaviour
    {
        [SerializeField] private float intervalSeconds;
        [SerializeField] private GameObject panel;

        private float _elapsed;
        private bool _isOpen;

        //===== Lifecycle =====

        private void Update()
        {
            _elapsed += Time.deltaTime;
            if (_isOpen || _elapsed < intervalSeconds) return;
            OpenUpgradeOffer();
        }

        //===== Event Handlers =====

        public void OnClickOption()
        {
            Time.timeScale = 1f;
            _elapsed = 0f;
            _isOpen = false;
            panel.gameObject.SetActive(false);
        }

        //===== Utilities =====

        private void OpenUpgradeOffer()
        {
            Time.timeScale = 0f;
            _isOpen = true;
            panel.gameObject.SetActive(true);
        }
    }
}