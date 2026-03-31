using System.Collections.Generic;
using Features.Panel.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Features.Panel.Scripts
{
    public class MainMenuPanel : MonoBehaviour
    {
        [SerializeField] private GameObject mainPage;
        [SerializeField] private GameObject guidePage;
        [SerializeField] private GameObject creditsPage;
        [SerializeField] private GameObject backButton;

        private Dictionary<MainMenuPage, GameObject> _pageMap;

        //===== Lifecycle =====

        private void Awake()
        {
            _pageMap = new Dictionary<MainMenuPage, GameObject>
            {
                { MainMenuPage.Main, mainPage },
                { MainMenuPage.Guide, guidePage },
                { MainMenuPage.Credits, creditsPage }
            };
        }

        //===== Event Handlers =====

        public void StartGame() => SceneManager.LoadScene("GameScene");
        
        public void OpenMainPage() => ShowPage(MainMenuPage.Main);

        public void OpenGuidePage() => ShowPage(MainMenuPage.Guide);

        public void OpenCreditsPage() => ShowPage(MainMenuPage.Credits);

        //===== Utilities =====

        private void ShowPage(MainMenuPage page)
        {
            foreach (var (key, value) in _pageMap)
            {
                value.SetActive(key == page);
                backButton.SetActive(key != MainMenuPage.Main);
            }
        }
    }
}