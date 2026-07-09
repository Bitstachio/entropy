using System;
using Core.Constants;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Services.Scene;
using UnityEngine;
using VContainer.Unity;

namespace Features.Orchestration
{
    public sealed class Orchestrator : IStartable, IDisposable
    {
        private readonly IEventPublisher<GameOverEvent> _gameOverPublisher;
        private readonly IEventListener<RockHitObjectEvent> _rockHitObjectListener;

        private readonly ISceneService _sceneService;

        public Orchestrator(
            IEventPublisher<GameOverEvent> gameOverPublisher,
            IEventListener<RockHitObjectEvent> rockHitObjectListener,
            ISceneService sceneService)
        {
            _gameOverPublisher = gameOverPublisher;
            _rockHitObjectListener = rockHitObjectListener;
            _sceneService = sceneService;
        }

        //===== Lifecycle =====

        public void Start() => _rockHitObjectListener.OnPublished += HandleRockHitObject;

        public void Dispose() => _rockHitObjectListener.OnPublished -= HandleRockHitObject;

        //===== Event Handlers =====

        private void HandleRockHitObject(RockHitObjectEvent @event)
        {
            if (!@event.Collision.collider.CompareTag(Tags.Player)) return;
            Time.timeScale = 0f;
            _gameOverPublisher.Publish(new GameOverEvent());
            _sceneService.Load(Scenes.GameOver);
        }
    }
}