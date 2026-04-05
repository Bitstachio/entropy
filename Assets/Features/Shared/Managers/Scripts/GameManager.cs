using Features.Shared.Constants;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Features.Shared.Managers.Scripts
{
    /// <summary>
    /// Coordinates run state (score, game over, scene transitions, etc.).
    /// </summary>
    /// <remarks>
    /// For now this stays deliberately simple: other behaviours reference this manager
    /// (e.g. serialized field) and call its methods directly. Related systems such as
    /// audio are invoked from those methods rather than through a decoupled event or
    /// channel layer. That centralizes orchestration but works against SOLID-style
    /// separation; revisiting architecture (events, services, ScriptableObject channels)
    /// is a planned follow-up when there is time to refactor.
    /// </remarks>
    // TODO: Remove log statements
    public sealed class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private readonly UnityEvent<float> _onScoreUpdated = new();
        private float _score;

        //===== Lifecycle =====

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(gameObject);
            else
            {
                Instance = this;
                _score = 0f;
            }
        }

        //===== Public API =====

        public void AddScoreUpdateListener(UnityAction<float> listener) => _onScoreUpdated.AddListener(listener);

        public void RemoveScoreUpdateListener(UnityAction<float> listener) => _onScoreUpdated.RemoveListener(listener);

        //===== Event Handlers =====

        public void OnRockDestroyed(float rockValue) => _onScoreUpdated.Invoke(_score += rockValue);

        public void OnPlayerHitRock() => SceneManager.LoadScene(Scenes.GameOver);
    }
}