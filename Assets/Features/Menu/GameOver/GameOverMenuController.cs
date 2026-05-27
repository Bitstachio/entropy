using System;
using System.Threading.Tasks;
using Core.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Features.Menu.GameOver
{
    public sealed class GameOverMenuController : IStartable, IDisposable
    {
        private readonly IGameOverMenuModel _model;
        private readonly IGameOverMenuView _view;
        
        public GameOverMenuController(IGameOverMenuModel model, IGameOverMenuView view)
        {
            _model = model;
            _view = view;
        }

        //===== Lifecycle =====

        public void Start()
        {
            _view.OnRetrySelected += HandleRetrySelected;
            _view.OnHomeSelected += HandleHomeSelected;
        }

        public void Dispose()
        {
            _view.OnRetrySelected -= HandleRetrySelected;
            _view.OnHomeSelected -= HandleHomeSelected;
        }

        //===== Event Handlers =====

        private void HandleRetrySelected() => LoadScene(Scenes.Game);

        private void HandleHomeSelected() => LoadScene(Scenes.Main);

        //===== Utilities =====

        private async void LoadScene(string scene)
        {
            try
            {
                await Task.Delay(_model.SceneLoadDelay);
                SceneManager.LoadScene(scene);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load scene '{scene}': {e.Message}");
            }
        }
    }
}