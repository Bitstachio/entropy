using Features.Shared.Managers.Scripts;
using TMPro;
using UnityEngine;

namespace Features.Panel.Scripts
{
    public class HudPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private GameManager _gameManager;

        //===== Lifecycle =====

        private void Start()
        {
            _gameManager = GameManager.Instance;
            if (_gameManager == null)
            {
                Debug.LogError($"{nameof(HudPanel)}: GameManager.Instance is null");
                return;
            }

            _gameManager.AddScoreUpdateListener(UpdateScore);
            UpdateScore(0f);
        }

        private void OnDisable() => _gameManager?.RemoveScoreUpdateListener(UpdateScore);

        //===== Event Handlers =====

        public void UpdateScore(float score) => scoreText.text = Mathf.RoundToInt(score).ToString();
    }
}