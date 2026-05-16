using Core.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Features.Panel
{
    public sealed class GameOverPanel : MonoBehaviour
    {
        //===== Event Handlers =====

        public void LoadGameScene() => SceneManager.LoadScene(Scenes.Game);

        public void LoadMainMenuScene() => SceneManager.LoadScene(Scenes.Main);
    }
}