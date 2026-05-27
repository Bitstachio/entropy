using System.Collections;
using System.Collections.Generic;
using Core.Audio.Sfx;
using Core.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Features.Menu
{
    public sealed class MainMenuPanel : MonoBehaviour
    {
        private enum Page
        {
            Main,
            Guide,
            Credits
        }

        [SerializeField] private GameObject mainPage;
        [SerializeField] private GameObject guidePage;
        [SerializeField] private GameObject creditsPage;
        [SerializeField] private GameObject backButton;

        // I don't want to deal with event-driven architecture for simple UI scripts (for now)
        [SerializeField] private SfxPlayer sfxPlayer;
        [SerializeField] private AudioClip clickClip;
        
        private Dictionary<Page, GameObject> _pageMap;

        //===== Lifecycle =====

        private void Awake()
        {
            _pageMap = new Dictionary<Page, GameObject>
            {
                { Page.Main, mainPage },
                { Page.Guide, guidePage },
                { Page.Credits, creditsPage }
            };
        }

        //===== Event Handlers =====

        public void LoadGameScene()
        {
            sfxPlayer.Play(clickClip, 1f);
            StartCoroutine(ExecuteAfterDelayCoroutine(0.2f));
        }

        public void ShowMainPage() => ShowPage(Page.Main);

        public void ShowGuidePage() => ShowPage(Page.Guide);

        public void ShowCreditsPage() => ShowPage(Page.Credits);

        //===== Utilities =====

        private void ShowPage(Page page)
        {
            sfxPlayer.Play(clickClip, 1f);
            backButton.SetActive(page != Page.Main);
            foreach (var (key, value) in _pageMap)
                value.SetActive(key == page);
        }
        
        // A little bit of delay for click sound to finish before loading the game scene
        private static IEnumerator ExecuteAfterDelayCoroutine(float delayInSeconds)
        {
            yield return new WaitForSeconds(delayInSeconds);
            SceneManager.LoadScene(Scenes.Game);
        }
    }
}