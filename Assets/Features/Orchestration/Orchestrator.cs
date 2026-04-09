using System;
using System.Threading.Tasks;
using Core.Constants;
using Core.Enums;
using Core.Events.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace Features.Orchestration
{
    public sealed class Orchestrator : IStartable, IDisposable
    {
        private readonly int _gameOverDelay;

        private readonly IEventPublisher _gameOverPublisher;
        private readonly IEventListener<string> _rockHitObjectListener;

        public Orchestrator(int gameOverDelay,
            [Key(GameEventType.GameOver)] IEventPublisher gameOverPublisher,
            [Key(GameEventType.RockHitObject)] IEventListener<string> rockHitObjectListener)
        {
            _gameOverDelay = gameOverDelay;
            _gameOverPublisher = gameOverPublisher;
            _rockHitObjectListener = rockHitObjectListener;
        }

        //===== Lifecycle =====

        public void Start() => _rockHitObjectListener.OnPublished += HandleRockHitObject;

        public void Dispose() => _rockHitObjectListener.OnPublished -= HandleRockHitObject;

        //===== Event Handlers =====

        private void HandleRockHitObject(string tag)
        {
            if (tag != Tags.Player) return;
            Time.timeScale = 0f;
            _gameOverPublisher.Publish();
            LoadGameOverScene(_gameOverDelay);
        }

        //===== Utilities =====

        private static async void LoadGameOverScene(int delay)
        {
            try
            {
                await Task.Delay(delay);
                SceneManager.LoadScene("GameOverScene");
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load scene: {e.Message}");
            }
        }
    }
}