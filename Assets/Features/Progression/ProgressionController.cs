using System;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Features.Progression.Interfaces;
using VContainer.Unity;

namespace Features.Progression
{
    public class ProgressionController : IStartable, IDisposable
    {
        private readonly IProgressionModel _model;
        private readonly IProgressionView _view;

        private readonly IEventListener<GameOverEvent> _gameOverListener;
        private readonly IEventListener<RockDestroyedEvent> _rockDestroyedListener;

        public ProgressionController(IProgressionModel model, IProgressionView view,
            IEventListener<GameOverEvent> gameOverListener,
            IEventListener<RockDestroyedEvent> rockDestroyedListener)
        {
            _model = model;
            _view = view;
            _gameOverListener = gameOverListener;
            _rockDestroyedListener = rockDestroyedListener;
        }

        //===== Lifecycle =====

        public void Start()
        {
            _gameOverListener.OnPublished += HandleGameOver;
            _rockDestroyedListener.OnPublished += HandleRockDestroyed;

            _view.SetScore(_model.CurrentScore);
            _view.SetHighScore(_model.HighScore);
        }

        public void Dispose()
        {
            _gameOverListener.OnPublished -= HandleGameOver;
            _rockDestroyedListener.OnPublished -= HandleRockDestroyed;
        }

        //===== Event Handlers =====

        private void HandleGameOver(GameOverEvent @event) => _model.UpdateHighScore();

        private void HandleRockDestroyed(RockDestroyedEvent @event)
        {
            _model.AddScore(@event.Durability);
            _view.SetScore(_model.CurrentScore);
            _view.SetHighScore(_model.HighScore);
        }
    }
}