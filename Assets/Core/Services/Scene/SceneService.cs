using System;
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
                // Must be realtime: game-over/pause set timeScale to 0, which stalls WaitForSecondsAsync.
                // Task.Delay is also unreliable on WebGL.
                await WaitRealtimeAsync(_config.Delay / 1000f);

                SceneManager.LoadScene(scene);
                _timeScaleService.Resume();
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load scene '{scene}': {e.Message}");
            }
        }

        private static async Awaitable WaitRealtimeAsync(float seconds)
        {
            if (seconds <= 0f) return;

            var elapsed = 0f;
            while (elapsed < seconds)
            {
                elapsed += Time.unscaledDeltaTime;
                await Awaitable.NextFrameAsync();
            }
        }
    }
}
