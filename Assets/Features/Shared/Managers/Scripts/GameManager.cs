using UnityEngine;

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
    public class GameManager : MonoBehaviour
    {
        private float _score;
        
        //===== Event Handlers =====

        public void OnRockDestroyed(float rockValue)
        {
            Debug.Log($"Score {_score} + Rock Value {rockValue} = {_score + rockValue}");
            _score += rockValue;
        }

        public void OnPlayerHitRock()
        {
            Debug.Log("Player hit rock!");
        }
    }
}