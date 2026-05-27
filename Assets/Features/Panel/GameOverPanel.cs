using System.Collections;
using Core.Audio.Sfx;
using Core.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Features.Panel
{
    public sealed class GameOverPanel : MonoBehaviour
    {
        // I don't want to deal with event-driven architecture for simple UI scripts (for now)
        [SerializeField] private SfxPlayer sfxPlayer;
        [SerializeField] private AudioClip clickClip;
        
        //===== Event Handlers =====

        public void LoadGameScene()
        {
            sfxPlayer.Play(clickClip, 1f);
            StartCoroutine(ExecuteAfterDelayCoroutine(0.2f, Scenes.Game));
        }

        public void LoadMainMenuScene()
        {
            sfxPlayer.Play(clickClip, 1f);
            StartCoroutine(ExecuteAfterDelayCoroutine(0.2f, Scenes.Main));
        }

        //===== Utilities =====
        
        private static IEnumerator ExecuteAfterDelayCoroutine(float delayInSeconds, string scene)
        {
            yield return new WaitForSeconds(delayInSeconds);
            SceneManager.LoadScene(scene);
        }
    }
}