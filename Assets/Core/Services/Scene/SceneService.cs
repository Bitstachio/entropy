using System;
using System.Threading.Tasks;
using Core.Services.TimeScale;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Services.Scene
{
    public sealed class SceneService : ISceneService
    {
        private readonly ITimeScaleService _timeScaleService;

        private readonly SceneServiceConfig _config;

        public SceneService(ITimeScaleService timeScaleService, SceneServiceConfig config)
        {
            _timeScaleService = timeScaleService;
            _config = config;
        }

        public async void Load(string scene)
        {
            try
            {
                await Task.Delay(_config.Delay);
                SceneManager.LoadScene(scene);
                _timeScaleService.Resume(); // Useful when loading a new scene from the game pause menu
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load scene '{scene}': {e.Message}");
            }
        }
    }
}