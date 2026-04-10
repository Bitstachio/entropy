using System;
using System.Threading.Tasks;
using Core.Constants;
using Core.Events.Channels;
using Core.Events.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Features.Orchestration
{
    public sealed class Orchestrator : IStartable, IDisposable
    {
        private readonly int _gameOverDelay;

        private readonly IEventPublisher<GameOverEvent> _gameOverPublisher;
        private readonly IEventListener<RockHitObjectEvent> _rockHitObjectListener;

        public Orchestrator(int gameOverDelay,
            IEventPublisher<GameOverEvent> gameOverPublisher,
            IEventListener<RockHitObjectEvent> rockHitObjectListener)
        {
            _gameOverDelay = gameOverDelay;
            _gameOverPublisher = gameOverPublisher;
            _rockHitObjectListener = rockHitObjectListener;
        }

        //===== Lifecycle =====

        public void Start() => _rockHitObjectListener.OnPublished += HandleRockHitObject;

        public void Dispose() => _rockHitObjectListener.OnPublished -= HandleRockHitObject;

        //===== Event Handlers =====

        private void HandleRockHitObject(RockHitObjectEvent @event)
        {
            if (@event.Tag != Tags.Player) return;
            Time.timeScale = 0f;
            _gameOverPublisher.Publish(new GameOverEvent());
            LoadGameOverScene(_gameOverDelay);
        }

        //===== Utilities =====

        private static async void LoadGameOverScene(int delay)
        {
            try
            {
                await Task.Delay(delay);
                // Guard against executing engine logic if the user stopped the editor or quit during the async delay
                if (!Application.isPlaying) return;
                SceneManager.LoadScene("GameOverScene");
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load scene: {e.Message}");
            }
            finally
            {
                Time.timeScale = 1f;
            }
        }
    }
}