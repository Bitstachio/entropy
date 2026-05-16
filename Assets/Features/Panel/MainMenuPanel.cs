using System.Collections.Generic;
using Core.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Features.Panel
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

        public void LoadGameScene() => SceneManager.LoadScene(Scenes.Game);

        public void ShowMainPage() => ShowPage(Page.Main);

        public void ShowGuidePage() => ShowPage(Page.Guide);

        public void ShowCreditsPage() => ShowPage(Page.Credits);

        //===== Utilities =====

        private void ShowPage(Page page)
        {
            backButton.SetActive(page != Page.Main);
            foreach (var (key, value) in _pageMap)
                value.SetActive(key == page);
        }
    }
}