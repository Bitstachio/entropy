using Features.Player.Upgrade.Scripts.UI;
using Features.Shared.Utils;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace Features.Player.Upgrade.Scripts
{
    public class UpgradeController : MonoBehaviour
    {
        [SerializeField] private float intervalSeconds;
        [SerializeField] private GameObject offerPanel;
        [SerializeField] private Button[] options;
        [SerializeField] private Options.Upgrade[] upgrades;
        
        private static readonly Random Rng = new Random();

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
            ArrayUtils.Shuffle(upgrades, Rng);

            // TODO: Assert upgrades.Length >= options.Length
            for (var i = 0; i < options.Length; i++)
            {
                var behaviour = options[i].GetComponent<UpgradeOption>();
                behaviour.SetContent(upgrades[i].Description);
                options[i].onClick.AddListener(upgrades[i].Apply);
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